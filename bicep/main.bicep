param computer_vision_name string = 'cv-computer-vision-australiaeast-001'
param location string = resourceGroup().location

resource accounts_cv_computer_vision_australiaeast_001_name_resource 'Microsoft.CognitiveServices/accounts@2025-06-01' = {
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
