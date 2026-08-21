# Database Files

This folder contains JSON files that act as the database for this OAuth/OIDC learning project.

## Files

### users.json
Contains user accounts for the custom Identity Server. Each user has:
- `id` - Unique identifier
- `email` - User email (must match firm domain for routing)
- `firstName` - First name
- `lastName` - Last name
- `role` - User role (`user` or `admin`)
- `passwordHash` - BCrypt hashed password
- `salt` - BCrypt salt

**Default test credentials:**

**Firm 1 - yourcompany.com (custom IdP):**
- Email: `john@yourcompany.com` | Password: `password123` | Role: `user`
- Email: `admin@yourcompany.com` | Password: `password123` | Role: `admin`

**Firm 2 - acme.com (Okta IdP):**
- Email: `alice@acme.com` | Password: `password123` | Role: `user`

**Firm 3 - techcorp.com (OneLogin IdP):**
- Email: `bob@techcorp.com` | Password: `password123` | Role: `user`

### firms.json
Contains firm/organization configurations and their IdP settings. Each firm has:
- `id` - Unique identifier
- `name` - Firm/company name
- `domain` - Email domain (e.g., `yourcompany.com`)
- `idpType` - Type of IdP (`custom`, `okta`, `onelogin`)
- `idpConfig` - Configuration details for the IdP

**Firm types:**
1. **custom** - Uses your local Identity Server (Port 5001)
2. **okta** - Uses Okta as external IdP
3. **onelogin** - Uses OneLogin as external IdP

## How It Works

When a user logs in:
1. Identity Server receives email (e.g., `john@acme.com`)
2. Extracts domain (`acme.com`)
3. Looks up domain in `firms.json`
4. Routes to appropriate IdP:
   - If `idpType: "custom"` → Check `users.json` for credentials
   - If `idpType: "okta"` → Redirect to Okta
   - If `idpType: "onelogin"` → Redirect to OneLogin

## Adding New Users

Edit `users.json` and add a new entry:
```json
{
  "id": "user-003",
  "email": "newuser@yourcompany.com",
  "firstName": "New",
  "lastName": "User",
  "role": "user",
  "passwordHash": "$2b$12$...",
  "salt": "$2b$12$..."
}
```

## Adding New Firms

Edit `firms.json` and add a new entry:
```json
{
  "id": "firm-005",
  "name": "New Company",
  "domain": "newcompany.com",
  "idpType": "custom",
  "idpConfig": {
    "authority": "http://localhost:5001",
    "redirectUri": "http://localhost:4200/callback"
  }
}
```

## Password Hashing (for reference)

Passwords are hashed using BCrypt. The default test password `password123` is already hashed in the sample data.

To generate new password hashes, use a BCrypt tool or generate them in code:
- C#: Use `BCrypt.Net.BCrypt.HashPassword("password")`
- Node: Use `bcryptjs.hashSync("password", 10)`

## Important Notes

- **No real data:** This is test data only for learning purposes
- **Security:** In production, use a real database with proper security
- **Credentials visible:** Passwords are hashed, but config is not encrypted (not suitable for production)
