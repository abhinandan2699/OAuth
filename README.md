# OAuth/OIDC Learning Project

A learning application demonstrating OAuth 2.0 / OpenID Connect (OIDC) concepts with multi-tenant identity management.

## Project Structure

```
├── Backend/          # Main API Server (Port 5000)
├── IdentityServer/   # Custom Identity Server (Port 5001)
├── Frontend/         # Angular App (Port 4200)
├── database/         # JSON file-based database
└── docs/             # Documentation
```

## Quick Start

See `CLAUDE.md` for detailed development phases and instructions.

### Prerequisites
- .NET 10 SDK
- Node.js 18+
- Angular CLI

### Running Projects

**Backend API:**
```bash
cd Backend/Backend
dotnet run
# Runs on http://localhost:5000
```

**Identity Server:**
```bash
cd IdentityServer/IdentityServer
dotnet run
# Runs on http://localhost:5001
```

**Angular Frontend:**
```bash
cd Frontend
npm start
# Runs on http://localhost:4200
```

## Development Approach

This project follows a **phase-by-phase incremental development** approach. Each phase adds one small feature that is tested and committed.

See `CLAUDE.md` for the complete phase breakdown.

## Current Phase

**Phase 0:** ✅ Initial project scaffolding complete
