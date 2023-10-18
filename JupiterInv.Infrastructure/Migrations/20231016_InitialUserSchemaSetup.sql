CREATE TABLE "Tenants" (
    "Id" UUID PRIMARY KEY,
    "Name" VARCHAR(256) NOT NULL UNIQUE
);

CREATE TABLE "Roles" (
    "Id" UUID PRIMARY KEY,
    "TenantId" UUID REFERENCES "Tenants"("Id"),
    "Name" VARCHAR(256) NOT NULL,
    "NormalizedName" VARCHAR(256) NOT NULL UNIQUE
);

CREATE INDEX "idx_roles_tenant_id" ON "Roles"("TenantId");

CREATE TABLE "Users" (
    "Id" UUID PRIMARY KEY,
    "UserName" VARCHAR(256) NOT NULL UNIQUE,
    "NormalizedUserName" VARCHAR(256) NOT NULL UNIQUE,
    "Email" VARCHAR(256) UNIQUE,
    "NormalizedEmail" VARCHAR(256) UNIQUE,
    "EmailConfirmed" BOOLEAN NOT NULL,
    "PasswordHash" VARCHAR(256),
    "TenantId" UUID REFERENCES "Tenants"("Id"),
    "RoleId" UUID REFERENCES "Roles"("Id"),
    "SecurityStamp" VARCHAR(256),
    "LockoutEnd" TIMESTAMP,
    "LockoutEnabled" BOOLEAN NOT NULL
);

CREATE INDEX "idx_users_tenant_id" ON "Users"("TenantId");
CREATE INDEX "idx_users_role_id" ON "Users"("RoleId");
