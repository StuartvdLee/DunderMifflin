targetScope = 'resourceGroup'

@description('Location for all resources')
param location string = resourceGroup().location

@description('Name of the application')
param appName string = 'dundermifflin'

@description('SKU for the App Service Plan')
param skuName string = 'F1'

resource appServicePlan 'Microsoft.Web/serverfarms@2023-12-01' = {
  name: '${appName}-asp'
  location: location
  sku: {
    name: skuName
    tier: 'Free'
    size: skuName
    capacity: 1
  }
}
