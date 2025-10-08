# mslearn-ai-vision-csharp

C# implementation of [mslearn-ai-vision](https://github.com/MicrosoftLearning/mslearn-ai-vision)

These modules are used in the Microsoft Learn [Develop computer vision solutions in Azure](https://learn.microsoft.com/training/paths/create-computer-vision-solutions-azure-ai/?WT.mc_id=DOP-MVP-5001655) learning path.


## Development notes

## Infrastructure

```bash
az group create --location australiaeast --resource-group rg-computer-vision-australiaeast-001
```

```bash
# Prepare a service principal for Login with OIDC
az ad sp create-for-rbac --name sp-computer-vision-australiaeast-001 --role Contributor --scopes /subscriptions/<yoursubscription>/resourceGroups/rg-computer-vision-australiaeast-001
```

Make a note of the appId value, as you'll enter that as the `--id` parameter.

<https://learn.microsoft.com/entra/workload-id/workload-identity-federation-create-trust?pivots=identity-wif-apps-methods-azp&WT.mc_id=DOP-MVP-5001655#github-actions>

Create credential.json (update `octo-org` and `octo-repo` to the GitHub organisation/username and repository name respectively)

```json
{
    "name": "main",
    "issuer": "https://token.actions.githubusercontent.com",
    "subject": "repo:octo-org/octo-repo:ref:refs/heads/main",
    "description": "Main branch",
    "audiences": [
        "api://AzureADTokenExchange"
    ]
}
```

Use the `appId` value from above for the `--id` parameter

```bash
az ad app federated-credential create --id xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx --parameters credential.json
```

Get the Azure subscription ID:

```bash
az account subscription list
```

and then set the following as GitHub secrets

- AZURE_CLIENT_ID the Application (client) ID
- AZURE_TENANT_ID the Directory (tenant) ID
- AZURE_SUBSCRIPTION_ID your subscription ID

eg. via the GitHub CLI

```bash
gh secret set AZURE_CLIENT_ID --body "xxxx"
gh secret set AZURE_TENANT_ID --body "xxxx"
gh secret set AZURE_SUBSCRIPTION_ID --body "xxxxx"
```
