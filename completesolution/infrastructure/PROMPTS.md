# Copilot prompts used to complete this solution.

### PROMPT

> Refactor this code to modules

### RESULT

```hcl
provider azurerm {
  features {}
}

terraform {
  backend azurerm {
    resource_group_name  = "example-resources"
    storage_account_name = "examplestorageacc"
    container_name       = "tfstate"
    key                  = "terraform.tfstate"
  }
}

module resource_group {
  source   = "./modules/resource_group"
  location = "West Europe"
}

module container_registry {
  source                = "./modules/container_registry"
  resource_group_name   = module.resource_group.name
  location              = module.resource_group.location
  sku                   = "Basic"
  admin_enabled         = true
}

module key_vault {
  source                     = "./modules/key_vault"
  location                   = module.resource_group.location
  resource_group_name        = module.resource_group.name
  tenant_id                  = "your-tenant-id"
  sku_name                   = "standard"
  soft_delete_retention_days = 7
  purge_protection_enabled   = false
}

module key_vault_secret_acrusername {
  source        = "./modules/key_vault_secret"
  name          = "acrusername"
  value         = module.container_registry.admin_username
  key_vault_id  = module.key_vault.id
}

module key_vault_secret_acrpassword {
  source        = "./modules/key_vault_secret"
  name          = "acrpassword"
  value         = module.container_registry.admin_password
  key_vault_id  = module.key_vault.id
}
```

### PROMPT

> Generate the code that should be inside the module for the resource group to using it, creating a main.tf with all definitions, an output.tf with all module outputs (by default id and name in all modules plus another used field properties) and a variables.tf to define the input variables of the module

### RESULT

```hcl
# main.tf

resource azurerm_resource_group this {
  name     = var.resource_group_name
  location = var.location
}

# output.tf

output resource_group_id {
  value = azurerm_resource_group.this.id
}

output resource_group_name {
  value = azurerm_resource_group.this.name
}

# variables.tf

variable resource_group_name {
  description = "Name of the resource group"
  type        = string
}

variable location {
  description = "Location of the resource group"
  type        = string
}
```

### PROMPT

> Generate the code that should be inside the module for the container registry to using it, creating a main.tf with all definitions, an output.tf with all module outputs (by default id and name in all modules plus another used field properties) and a variables.tf to define the input variables of the module

### RESULT

```hcl
# main.tf

resource azurerm_container_registry this {
  name                = var.name
  resource_group_name = var.resource_group_name
  location            = var.location
  sku                 = var.sku
  admin_enabled       = var.admin_enabled
}

# output.tf

output container_registry_id {
  value = azurerm_container_registry.this.id
}

output container_registry_name {
  value = azurerm_container_registry.this.name
}

output container_registry_admin_username {
  value = azurerm_container_registry.this.admin_username
}

output container_registry_admin_password {
  value = azurerm_container_registry.this.admin_password
}

# variables.tf

variable name {
  description = "The name of the container registry"
  type        = string
}

variable resource_group_name {
  description = "The name of the resource group"
  type        = string
}

variable location {
  description = "The location of the container registry"
  type        = string
}

variable sku {
  description = "The SKU of the container registry"
  type        = string
}

variable admin_enabled {
  description = "Whether admin user is enabled for the container registry"
  type        = bool
}
```

### PROMPT

> Generate the code that should be inside the module for the key vault to using it, creating a main.tf with all definitions, an output.tf with all module outputs (by default id and name in all modules plus another used field properties) and a variables.tf to define the input variables of the module

### RESULT

```hcl
# main.tf

variable location {
  type    = string
  default = ""
}

variable resource_group_name {
  type    = string
  default = ""
}

variable tenant_id {
  type    = string
  default = ""
}

variable sku_name {
  type    = string
  default = ""
}

variable soft_delete_retention_days {
  type    = number
  default = 0
}

variable purge_protection_enabled {
  type    = bool
  default = false
}

resource azurerm_key_vault this {
  name                        = "example-key-vault"
  location                    = var.location
  resource_group_name         = var.resource_group_name
  tenant_id                   = var.tenant_id
  sku_name                    = var.sku_name
  soft_delete_retention_days  = var.soft_delete_retention_days
  purge_protection_enabled    = var.purge_protection_enabled

  tags = {
    environment = "production"
  }
}

# output.tf

output key_vault_id {
  value = azurerm_key_vault.this.id
}

output key_vault_name {
  value = azurerm_key_vault.this.name
}

output key_vault_properties {
  value = azurerm_key_vault.this.properties
}

# variables.tf

variable location {
  type    = string
  default = ""
}

variable resource_group_name {
  type    = string
  default = ""
}

variable tenant_id {
  type    = string
  default = ""
}

variable sku_name {
  type    = string
  default = ""
}

variable soft_delete_retention_days {
  type    = number
  default = 0
}

variable purge_protection_enabled {
  type    = bool
  default = false
}
```
