targetScope = 'resourceGroup'

@description('Name of the App Service Plan')
param appServicePlanName string = 'myAppServicePlan'

@description('Location for all resources')
param location string = resourceGroup().location

@description('SKU for the App Service Plan (e.g. F1 = Free, B1 = Basic, P1v3 = Premium)')
param skuName string = 'Super illegale waarde'

resource appServicePlan 'Microsoft.Web/serverfarms@2023-12-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: skuName
    tier: skuName == 'F1' ? 'Free' : skuName == 'B1' ? 'Basic' : 'Standard'
    size: skuName
    capacity: 1
  }
}
