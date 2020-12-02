# Define Terraform provider
terraform {
  required_version = ">= 0.12"
}

# Configure the Azure provider
provider "azurerm" {
  environment = "public"
  version     = ">= 2.15.0"
  features {}
}

terraform {
    backend "azurerm" {
        resource_group_name  = "Redington"
        storage_account_name = "redingtonterraformsa"
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
  name                = "RedingtonASPLinux"
  location            = azurerm_resource_group.tfrg_test.location
  resource_group_name = azurerm_resource_group.tfrg_test.name
  kind                = "Linux"
  reserved            = true
  sku {
    tier = "Standard"
    size = "S1"
  }
}

