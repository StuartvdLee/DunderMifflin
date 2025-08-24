targetScope = 'resourceGroup'

@description('Name of the App Service Plan')
param appServicePlanName string = 'myAppServicePlan'

@description('Location for all resources')
param location string = resourceGroup().location

@description('SKU for the App Service Plan')
param skuName string = 'F1'

resource appServicePlan 'Microsoft.Web/serverfarms@2023-12-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: skuName
    tier: 'Free'
    size: skuName
    capacity: 1
  }
}
