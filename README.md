# Unity Package Template
Template repository for custom Unity package development.

## Overview
- The default project location is `Project`.
- The default package location is `Project/Assets/Package`.
- A GitHub Actions pipeline that builds from `master` and deploys to `upm`.
- A preamble file at `preamble.txt`.
	- The contents will be prepended to all source code files prior to deployment.

## Quick Start
### GitHub Setup
1. Click "Use this template" (above).
2. Follow the "Create a new repository" wizard.
	- OPTIONAL: check "Include all branches" to include the recommended branching workflow.

### Local Setup
1. Clone the project to your workstation.
2. Run `init.sh` to setup the Unity project.
3. Edit the package manifest with your package's details. (Ex. `Project/Assets/Package/project.json`).

### GitHub Actions Setup
1. Edit `.github/workflows/main.yml`.
	- Change `PACKAGE_ROOT` to your package directory.
