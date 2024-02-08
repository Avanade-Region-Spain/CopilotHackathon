provider azurerm {
  features {}

  subscription_id = "your-subscription-id"
  tenant_id       = "your-tenant-id"
  client_id       = "your-client-id"
  client_secret   = "your-client-secret"
}

terraform {
  backend azurerm {
    resource_group_name  = "example-resources"
    storage_account_name = "examplestorageacc"
    container_name       = "tfstate"
    key                  = "terraform.tfstate"
  }
}

resource azurerm_resource_group this {
  name     = "example-resources"
  location = "West Europe"
}

resource azurerm_container_registry this {
  name                     = "exampleacr"
  resource_group_name      = azurerm_resource_group.this.name
  location                 = azurerm_resource_group.this.location
  sku                      = "Basic"
  admin_enabled            = true
}

resource azurerm_key_vault this {
  name                        = "examplekv"
  location                    = azurerm_resource_group.this.location
  resource_group_name         = azurerm_resource_group.this.name
  tenant_id                   = "your-tenant-id"
  sku_name                    = "standard"
  soft_delete_retention_days  = 7
  purge_protection_enabled    = false
}

resource azurerm_key_vault_secret acrusername {
  name         = "acrusername"
  value        = azurerm_container_registry.this.admin_username
  key_vault_id = azurerm_key_vault.this.id
}

resource azurerm_key_vault_secret acrpassword {
  name         = "acrpassword"
  value        = azurerm_container_registry.this.admin_password
  key_vault_id = azurerm_key_vault.this.id
}
