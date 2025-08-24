targetScope = 'resourceGroup'

@description('Location for all resources')
param location string = resourceGroup().location

@description('Name of the application')
param appName string = 'dundermifflin'

@description('SKU for the App Service Plan')
param skuName string = 'F1'

resource appServicePlan 'Microsoft.Web/serverfarms@2024-11-01' = {
  name: '${appName}-asp'
  location: location
  kind: 'linux'
  sku: {
    name: skuName
    tier: 'Free'
    size: skuName
    capacity: 0
  }
  properties: {
    reserved: true // For Linux
  }
}
