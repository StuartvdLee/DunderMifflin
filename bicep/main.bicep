targetScope = 'resourceGroup'

@description('Location for all resources')
param location string = resourceGroup().location

@description('administratorLogin for PostgreSQL server')
@secure()
param postgresqlAdministratorLogin string

@description('administratorLoginPassword for PostgreSQL server')
@secure()
param administratorLoginPassword string

@description('Name of the application')
param appName string = 'dundermifflin'

resource appServicePlan 'Microsoft.Web/serverfarms@2024-11-01' = {
  name: '${appName}-asp'
  location: location
  kind: 'linux'
  sku: {
    name: 'F1' // Free tier
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

resource postgresqlServer 'Microsoft.DBforPostgreSQL/flexibleServers@2024-08-01' = {
  name: '${appName}-psql'
  location: location
  sku: {
    name: 'Standard_B1ms'
    tier: 'Burstable'
  }
  properties: {
    administratorLogin: postgresqlAdministratorLogin
    administratorLoginPassword: administratorLoginPassword
    version: '17'
    storage: {
      storageSizeGB: 32
      autoGrow: 'Disabled'
      tier: 'P4'
    }
    backup: {
      backupRetentionDays: 7
      geoRedundantBackup: 'Disabled'
    }
    highAvailability: {
      mode: 'Disabled'
    }
  }
}
