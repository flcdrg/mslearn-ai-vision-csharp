param computer_vision_name string = 'cv-computer-vision-eastus-001'
param location string = resourceGroup().location

// https://learn.microsoft.com/azure/templates/microsoft.cognitiveservices/2025-06-01/accounts?pivots=deployment-language-bicep&WT.mc_id=DOP-MVP-5001655
resource accounts_cv_computer_vision 'Microsoft.CognitiveServices/accounts@2025-06-01' = {
  name: computer_vision_name
  location: location
  sku: {
    name: 'F0'
  }
  kind: 'ComputerVision'
  identity: {
    type: 'None'
  }
  properties: {
    customSubDomainName: computer_vision_name
    networkAcls: {
      defaultAction: 'Allow'
      virtualNetworkRules: []
      ipRules: []
    }
    allowProjectManagement: false
    publicNetworkAccess: 'Enabled'
  }
}
