# Define Terraform provider
terraform {
  required_version = ">= 0.12"
}

provider "azurerm" {
  version = "=2.5.0"
  subscription_id = var.ARM_SUBSCRIPTION_ID
  client_id       = var.ARM_CLINET_ID
  client_secret   = var.ARM_CLINET_SECRET 
  tenant_id       = var.ARM_TENANT_ID
  features {}
}

terraform {
    backend "azurerm" {
        resource_group_name  = "TerraformBlobStore"
        storage_account_name = "terraformblobstore"
        container_name       = "terraformstate"
        key                  = "terraform.tfstate"
	use_msi              = true
	subscription_id      = "var.ARM_SUBSCRIPTION_ID"
	tenant_id            = "var.ARM_TENANT_ID"		
    }
}

variable "imagebuild" {
  type        = string
  description = "Latest Image Build"
}

resource "azurerm_resource_group" "tfrg_test" {
  name = "Redington"
  location = "UK South"
}

resource "azurerm_app_service_plan" "tfrg-asp" {
  name                = "RedingtonASP"
  location            = azurerm_resource_group.tfrg_test.location
  resource_group_name = azurerm_resource_group.tfrg_test.name
  kind                = "Linux"
  reserved            = true
  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "tfrg-as" {
  name                = "RedingtonCalculator"
  location            = azurerm_resource_group.tfrg_test.location
  resource_group_name = azurerm_resource_group.tfrg_test.name
  app_service_plan_id = azurerm_app_service_plan.tfrg-asp.id
  app_settings = {
    WEBSITES_ENABLE_APP_SERVICE_STORAGE = false
    DOCKER_REGISTRY_SERVER_URL      = "https://redingtoncr.azurecr.io"
    DOCKER_REGISTRY_SERVER_USERNAME = "var.ARM_CLINET_ID"
    DOCKER_REGISTRY_SERVER_PASSWORD = "var.ARM_CLINET_SECRET"
  }
  site_config {
    linux_fx_version = "DOCKER|redingtoncalculator:${var.imagebuild}" 
    always_on        = "true"
  }
  identity {
    type = "SystemAssigned"
  }
}


