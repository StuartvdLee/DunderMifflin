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
  }
  properties: {
    reserved: true // For Linux
  }
}

resource appService 'Microsoft.Web/sites@2024-11-01' = {
  name: '${appName}-app-azurefest' // Temp name because dundermifflin-app is being held hostage in another subscription
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    clientAffinityEnabled: false
    httpsOnly: true
    publicNetworkAccess: 'Enabled'
    siteConfig: {
      appSettings: []
      linuxFxVersion: 'DOTNETCORE|9.0'
      alwaysOn: false
      ftpsState: 'FtpsOnly'
    }
  }
}
