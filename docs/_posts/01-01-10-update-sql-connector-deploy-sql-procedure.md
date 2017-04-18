---
title: Update SQL API Connector and deploy SQL Procedure
description:
category: SETUP
---

{% include header.md %}

## Update SQL API Connector

The Logic App uses SQL API Connection to access Mobile Claims and CRM Claims database. To authorize the Logic App to call the Mobile Claims and CRM Claim database API, follow these steps.
​
1. Open the **CRM SQL API Connection**.	

   ![]({{site.baseurl}}/img/deployment/azure-crm-sql-api-connection.png)

3. Click the **orange alert**.

   ![]({{site.baseurl}}/img/deployment/azure-crm-sql-api-connection-01.png)

4. Type the SQL server name, SQL database name, user name and password of the CRM Claim database, click **Save**.

   ![]({{site.baseurl}}/img/deployment/azure-crm-sql-api-connection-02.png)

5. Open the **Mobile API Connection**.	

   ![]({{site.baseurl}}/img/deployment/azure-mobile-sql-api-connection.png)

6. Click the **orange alert**.

   ![]({{site.baseurl}}/img/deployment/azure-mobile-sql-api-connection-01.png)

7. Type the SQL server name, SQL database name, user name and password of the Mobile Claim database, click **Save**.

   ![]({{site.baseurl}}/img/deployment/azure-mobile-sql-api-connection-02.png)


## Deploy SQL Procedure

1. Find the **Create Insert_CRM_Claim PROC.sql** and **Create Insert_Mobile_Claim PROC.sql**

   ![]({{site.baseurl}}/img/deployment/azure-sql-procedure.png)

2. Deploy the **Create Insert_CRM_Claim PROC.sql** file to CRMClaims database.

3. Deploy the **Create Insert_Mobile_Claim PROC.sql** file to MobileClaims database.

