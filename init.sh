#!/usr/bin/env bash

read -p 'Package Name: ' packageName
read -p 'Author: ' author

projectName=$packageName

sed -i "s/<AUTHOR>/$author/g" LICENSE
sed -i "s/<AUTHOR>/$author/g" preamble.txt
git mv "Project" "$projectName"
sed -i "s/productName: Project/productName: $projectName/g" "$projectName/ProjectSettings/ProjectSettings.asset"
git mv "$projectName/Assets/Package" "$projectName/Assets/$packageName"
git mv "$projectName/Assets/Package.meta" "$projectName/Assets/$packageName.meta"
