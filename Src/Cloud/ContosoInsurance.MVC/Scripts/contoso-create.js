;
var claimCreateFn = function () {
    var self = this;

    self.init = function () {
        self.createClaimForm = new self.CreateClaimFormFn();
        self.createClaimForm.init();

        ko.applyBindings(self, $(".claim-create-main").get(0));
    };

    self.relativeUrl = function (action) {
        var url = location.protocol + "//" + location.host + "/claims/" + action;
        return url;
    };


    self.Request = function (action,type,data, cb) {
        var url = self.relativeUrl(action);
        if (type == 'get')
            data["t"] = new Date().getTime();
        else
            data = JSON.stringify(data);
        $.ajax({
            dataType: 'json',
            url: url,
            data: data,
            contentType: 'application/json',
            type: type,
            success: cb
        });
    };

    self.CreateClaimFormFn = function () {
        var createForm = this;
        createForm.EnableSubmitButton = ko.observable(true);
        createForm.submitTip = ko.observable("");
        createForm.init = function () {
            openSection = function (evt, sectionName) {
                var i, x, tablinks;
                x = document.getElementsByClassName("section");
                for (i = 0; i < x.length; i++) {
                    x[i].style.display = "none";
                }
                tablinks = document.getElementsByClassName("tablink");
                for (i = 0; i < x.length; i++) {
                    tablinks[i].className = tablinks[i].className.replace(" claim-create-border-red", "");
                }
                document.getElementById(sectionName).style.display = "block";
                evt.currentTarget.firstElementChild.className += " claim-create-border-red";
            };
        };
        createForm.formData = {
            phonenumber: ko.observable(''),
            description:ko.observable('')
        };

        createForm.getPostData = function (formData) {
            return {
                phonenumber: formData.phonenumber(),
                description:formData.description()
            };
        };
        
        createForm.doSubmit = function () {
            if (!createForm.EnableSubmitButton())
                return;
            createForm.EnableSubmitButton(false);
            createForm.submitTip("The request is submitted. Please be patient to wait for the result.");
            self.Request('AddClaim', 'post', createForm.getPostData(createForm.formData), function (data) {
                console.log('submit');
                createForm.EnableSubmitButton(true);
                createForm.submitTip("");
                location.reload();
            });
        }
    };

};

$(function () {
    var claimCreate = new claimCreateFn();
    claimCreate.init();
});

