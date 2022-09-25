classDiagram
      
class AspNetRoles {
    ConcurrencyStamp
          Id
          Name
          NormalizedName
          
}
        
class AspNetUsers {
    AccessFailedCount
          Active
          Avatar
          Birthday
          ConcurrencyStamp
          Email
          EmailConfirmed
          FirstName
          Gender
          Id
          LastName
          LockoutEnabled
          LockoutEnd
          MiddleName
          NormalizedEmail
          NormalizedUserName
          PasswordHash
          PhoneNumber
          PhoneNumberConfirmed
          SecurityStamp
          TwoFactorEnabled
          UserName
          
}
        
class Branches {
    Id
          Name
          
}
        
class Colors {
    Id
          Name
          RGB
          
}
        
class PhoneDetails {
    Audio
          Battery
          Camera
          Capacity
          Charger
          Connection
          CPU
          Id
          OS
          RAM
          Screen
          Security
          
}
        
class Sales {
    CreatedAt
          CreatedBy
          Discount
          Effective
          Expired
          Id
          Status
          UpdatedAt
          UpdatedBy
          
}
        
class AspNetRoleClaims {
    ClaimType
          ClaimValue
          Id
          RoleId
          
}
        
class Addresses {
    Address
          CreatedAt
          CreatedBy
          Id
          Type
          UpdatedAt
          UpdatedBy
          UserId
          
}
        
class AspNetUserClaims {
    ClaimType
          ClaimValue
          Id
          UserId
          
}
        
class AspNetUserLogins {
    LoginProvider
          ProviderDisplayName
          ProviderKey
          UserId
          
}
        
class AspNetUserRoles {
    RoleId
          UserId
          
}
        
class AspNetUserTokens {
    LoginProvider
          Name
          UserId
          Value
          
}
        
class Orders {
    CreatedAt
          CreatedBy
          Id
          Status
          Total
          UpdatedAt
          UpdatedBy
          UserId
          
}
        
class Phones {
    BranchId
          CreatedAt
          CreatedBy
          Id
          Name
          Price
          SaleId
          UpdatedAt
          UpdatedBy
          
}
        
class Receipts {
    AddressId
          CreatedAt
          CreatedBy
          Description
          Id
          OrderId
          Seller
          Status
          UpdatedAt
          UpdatedBy
          
}
        
class Images {
    Id
          PhoneId
          Url
          
}
        
class Items {
    CreatedAt
          CreatedBy
          Id
          OrderId
          PhoneId
          Price
          Quantity
          Total
          UpdatedAt
          UpdatedBy
          
}
        
class __EFMigrationsHistory {
    MigrationId
          ProductVersion
          
}
        
class Stocks {
    ColorId
          CreatedAt
          CreatedBy
          Id
          PhoneDetailId
          PhoneId
          Quantity
          Status
          UpdatedAt
          UpdatedBy
          
}
        
      AspNetRoleClaims --|> AspNetRoles: Id
            Addresses --|> AspNetUsers: Id
            AspNetUserClaims --|> AspNetUsers: Id
            AspNetUserLogins --|> AspNetUsers: Id
            AspNetUserRoles --|> AspNetRoles: Id
            AspNetUserRoles --|> AspNetUsers: Id
            AspNetUserTokens --|> AspNetUsers: Id
            Orders --|> AspNetUsers: Id
            Phones --|> Branches: Id
            Phones --|> Sales: Id
            Receipts --|> Addresses: Id
            Receipts --|> Orders: Id
            Images --|> Phones: Id
            Items --|> Orders: Id
            Items --|> Phones: Id
            Stocks --|> Colors: Id
            Stocks --|> PhoneDetails: Id
            Stocks --|> Phones: Id
            
      