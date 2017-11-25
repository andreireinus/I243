@echo off
rd /q /s ClientApi

autorest --input-file=http://localhost:55451/swagger/v1/swagger.json --output-folder=ClientApi --enable-xml=false --csharp --sync-methods=none --client-side-validation=false --payload-flattening-threshold=1 --openapi-type=arm --namespace=Vault.UI.AdminForm.ClientApi