# OAuth/OIDC Learning Project

## Project Description
A learning application demonstrating OAuth 2.0 / OpenID Connect (OIDC) concepts with multi-tenant identity management. Users authenticate through different IdPs based on their email domain.

**Stack:** .NET 8 (Backend + Identity Server) | Angular 17+ (Frontend) | JSON Files (Database)

**Ports:** 
- Backend API: 5000
- Identity Server: 5001
- Angular Frontend: 4200

---

## Development Approach: Phase-by-Phase Implementation

### Philosophy
Build incrementally with **small, testable features**. Each phase adds one small piece of functionality.

**Process for Each Phase:**
1. Add one small feature (single component, endpoint, page, or service)
2. Test it locally to ensure it works
3. Commit to git with clear message
4. Move to next phase

### Why This Approach?
- ✅ Easy to understand what changed
- ✅ Can test each piece independently
- ✅ Easy to revert if something breaks
- ✅ Clear git history for learning
- ✅ Matches real development workflow

---

## Project Structure
```
OAuth/
├── Backend/              # Main API Server (Port 5000)
├── IdentityServer/       # Custom Identity Server (Port 5001)
├── Frontend/             # Angular App (Port 4200)
├── database/             # JSON file-based database
├── docs/                 # Documentation
├── CLAUDE.md            # This file
└── README.md            # Project README
```

---

## Implementation Phases

### Phase 0: Setup ✓
- [x] Initialize git repository
- [x] Create project folder structure
- [x] Create blank .NET Backend project
- [x] Create blank .NET IdentityServer project
- [x] Create blank Angular Frontend project
- [x] Create /database folder with initial structure
- **Commit:** "Initial project scaffolding"

### Phase 1: Database Setup
- [ ] Create users.json with test data
- [ ] Create firms.json with test data
- [ ] Create test data helpers
- **Commit:** "Add JSON database files with test data"

### Phase 2: Backend - User Profile Endpoint
- [ ] Create User model
- [ ] Create UserService to read from users.json
- [ ] Create UserController with GET /api/user/profile endpoint
- [ ] Add JWT middleware (without validation for now)
- **Commit:** "Add user profile endpoint"

### Phase 3: Backend - Firm Config Endpoint
- [ ] Create Firm model
- [ ] Create FirmService to read firms.json
- [ ] Create endpoint GET /api/firm/config/{domain}
- [ ] Test with various domains
- **Commit:** "Add firm config endpoint"

### Phase 4: Backend - Auth Logout Endpoint
- [ ] Create POST /api/auth/logout endpoint
- [ ] (For now, just return success)
- **Commit:** "Add logout endpoint"

### Phase 5: Identity Server - Login Page
- [ ] Create login.cshtml page with email input
- [ ] Create login.cshtml.cs with email domain detection
- [ ] Implement lookup in firms.json
- **Commit:** "Add Identity Server login page with domain detection"

### Phase 6: Identity Server - Local Authentication
- [ ] Create IdentityService for password validation
- [ ] Implement hash/salt password verification
- [ ] Create login logic for custom IdP users
- [ ] Generate JWT token with user claims
- **Commit:** "Add local authentication to Identity Server"

### Phase 7: Angular - Basic Project Setup
- [ ] Setup Angular project structure
- [ ] Configure environment files
- [ ] Install angular-auth-oidc-client library
- **Commit:** "Setup Angular project with OIDC client library"

### Phase 8: Angular - Auth Service
- [ ] Create AuthService with OIDC client initialization
- [ ] Implement login/logout methods
- [ ] Add token management in localStorage
- [ ] Create observables for auth state
- **Commit:** "Add AuthService with OIDC client"

### Phase 9: Angular - Auth Guards
- [ ] Create AuthGuard for protected routes
- [ ] Create RoleGuard for admin-only routes
- [ ] Test guards with different scenarios
- **Commit:** "Add route guards for authentication"

### Phase 10: Angular - Welcome Page
- [ ] Create welcome component
- [ ] Display user name and email from token claims
- [ ] Show logout button
- [ ] Add basic styling
- **Commit:** "Add welcome page with user info"

### Phase 11: Angular - Admin Section
- [ ] Add admin-only section to welcome page (or separate admin route)
- [ ] Show only if user has admin role
- [ ] Test with admin and non-admin users
- **Commit:** "Add admin section to welcome page"

### Phase 12: Angular - Callback Handling
- [ ] Create callback component
- [ ] Handle redirect from Identity Server
- [ ] Exchange auth code for token
- [ ] Navigate to welcome page
- **Commit:** "Add OIDC callback handling"

### Phase 13: Integration Testing
- [ ] Test complete flow: Login → Welcome Page → Logout
- [ ] Test with admin user (see admin section)
- [ ] Test with regular user (no admin section)
- [ ] Test token expiration behavior
- **Commit:** "Complete end-to-end flow working"

### Phase 14: External IdP Integration - Okta
- [ ] Add Okta configuration to firms.json
- [ ] Update Identity Server to handle Okta redirect
- [ ] Test Okta login flow
- **Commit:** "Add Okta OIDC integration"

### Phase 15: External IdP Integration - OneLogin
- [ ] Add OneLogin configuration to firms.json
- [ ] Update Identity Server to handle OneLogin redirect
- [ ] Test OneLogin login flow
- **Commit:** "Add OneLogin OIDC integration"

### Phase 16: Documentation & Cleanup
- [ ] Write setup instructions in README.md
- [ ] Document API endpoints
- [ ] Add comments to code
- [ ] Create SETUP.md with local development instructions
- **Commit:** "Add documentation and cleanup"

---

## Key Learning Checkpoints

After each phase, you should understand:
- **Phase 0-1:** Project structure and data format
- **Phase 2-4:** Basic REST API with multiple endpoints
- **Phase 5-6:** How Identity Server works and JWT token generation
- **Phase 7-9:** OIDC client configuration and route protection
- **Phase 10-13:** Complete OAuth/OIDC login flow
- **Phase 14-15:** Integrating with external IdPs (Okta, OneLogin)
- **Phase 16:** Deployment and documentation

---

## Database Files Format

### users.json
```json
[
  {
    "id": "user-001",
    "email": "john@acme.com",
    "firstName": "John",
    "lastName": "Doe",
    "role": "user",
    "passwordHash": "hashed_password",
    "salt": "salt_value"
  }
]
```

### firms.json
```json
[
  {
    "id": "firm-001",
    "name": "ACME Corp",
    "domain": "acme.com",
    "idpType": "custom",
    "idpConfig": { /* config details */ }
  }
]
```

---

## Running the Projects

### Start Backend API
```bash
cd Backend
dotnet run
# Runs on http://localhost:5000
```

### Start Identity Server
```bash
cd IdentityServer
dotnet run
# Runs on http://localhost:5001
```

### Start Angular Frontend
```bash
cd Frontend
npm start
# Runs on http://localhost:4200
```

---

## Debugging Tips

- **Check token in localStorage:** Open DevTools → Application → LocalStorage
- **Check console for errors:** DevTools Console tab
- **Monitor network requests:** DevTools Network tab
- **Identity Server logs:** Check console output when running

---

## Common Issues & Solutions

### CORS Errors
- Backend needs to allow requests from http://localhost:4200
- Check CORS configuration in Program.cs

### Token Not Stored
- Check browser's localStorage in DevTools
- Verify AuthService is storing token correctly

### Redirect Loop
- Check callback URL configuration
- Verify Identity Server redirect URI matches Angular config

---

## Next Steps
Start with **Phase 0** to initialize projects, then proceed sequentially.
