using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PainGuestApplication.Model.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditions",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    VersionNumber = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessLogs",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    AdminId = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    ReturnUrl = table.Column<string>(nullable: true),
                    LoginType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLogs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "B2BAccountInformations",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    RoutingNumber = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    B2BAccountID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BAccountInformations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "B2BAccountRooms",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    SpaceType = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Breadth = table.Column<int>(nullable: false),
                    UnitType = table.Column<int>(nullable: false),
                    IsCommercial = table.Column<bool>(nullable: false),
                    IsVacant = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CreatedByUserID = table.Column<string>(nullable: true),
                    UpdatedByUserID = table.Column<string>(nullable: true),
                    IsKitchenAvailable = table.Column<bool>(nullable: false),
                    IsVerandaAvailable = table.Column<bool>(nullable: false),
                    MonthlyAmount = table.Column<int>(nullable: false),
                    B2BAccountID = table.Column<string>(nullable: true),
                    PainGuestUserID = table.Column<string>(nullable: true),
                    IsBedAvailable = table.Column<bool>(nullable: false),
                    IsFurnitureAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BAccountRooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "B2BAccounts",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    GuestHouseName = table.Column<string>(nullable: true),
                    PrimaryContactUserID = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    AddLine1 = table.Column<string>(nullable: true),
                    AddLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    LoginEnabled = table.Column<bool>(nullable: false),
                    LanguageID = table.Column<string>(nullable: true),
                    HrManagerUserID = table.Column<string>(nullable: true),
                    BrokerUserID = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserID = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_B2BAccounts_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleInitial = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AadharNumber = table.Column<string>(nullable: true),
                    AlternateEmail = table.Column<string>(nullable: true),
                    AddLine1 = table.Column<string>(nullable: true),
                    AddLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    TerminationDate = table.Column<DateTime>(nullable: true),
                    TermsAndConditionsAcceptedOn = table.Column<DateTime>(nullable: true),
                    RegisteredOn = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    GenderDescription = table.Column<string>(nullable: true),
                    RegistrationStatus = table.Column<int>(nullable: false),
                    Usertype = table.Column<int>(nullable: false),
                    LanguageID = table.Column<string>(nullable: true),
                    B2BAccountID = table.Column<string>(nullable: true),
                    ProfileImageUrl = table.Column<string>(nullable: true),
                    Disablity = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    B2CObjectId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CreatedByUserID = table.Column<string>(nullable: true),
                    UpdatedByUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_B2BAccounts_B2BAccountID",
                        column: x => x.B2BAccountID,
                        principalTable: "B2BAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentTransactions",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    PainGuestID = table.Column<string>(nullable: true),
                    B2BAccountRoomID = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    TransactionReferenceNumber = table.Column<string>(nullable: true),
                    CreatedByUserID = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTransactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RentTransactions_B2BAccountRooms_B2BAccountRoomID",
                        column: x => x.B2BAccountRoomID,
                        principalTable: "B2BAccountRooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentTransactions_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentTransactions_AspNetUsers_PainGuestID",
                        column: x => x.PainGuestID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ReviewComment = table.Column<string>(nullable: true),
                    ReviewerRating = table.Column<int>(nullable: false),
                    ReviewerID = table.Column<string>(nullable: true),
                    B2BAccountID = table.Column<string>(nullable: true),
                    RoomID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_B2BAccounts_B2BAccountID",
                        column: x => x.B2BAccountID,
                        principalTable: "B2BAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewerID",
                        column: x => x.ReviewerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_B2BAccountRooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "B2BAccountRooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTermsAcceptances",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    TermsAndConditionsID = table.Column<string>(nullable: true),
                    DocumentType = table.Column<int>(nullable: false),
                    AgreementID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTermsAcceptances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTermsAcceptances_TermsAndConditions_TermsAndConditionsID",
                        column: x => x.TermsAndConditionsID,
                        principalTable: "TermsAndConditions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTermsAcceptances_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PainGuestAgreements",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    B2BAccountID = table.Column<string>(nullable: true),
                    UserTermsAcceptanceID = table.Column<string>(nullable: true),
                    PainGuestID = table.Column<string>(nullable: true),
                    AdvanceRentTransactionID = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<string>(nullable: true),
                    CreatedByUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainGuestAgreements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PainGuestAgreements_RentTransactions_AdvanceRentTransactionID",
                        column: x => x.AdvanceRentTransactionID,
                        principalTable: "RentTransactions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainGuestAgreements_B2BAccounts_B2BAccountID",
                        column: x => x.B2BAccountID,
                        principalTable: "B2BAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainGuestAgreements_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainGuestAgreements_AspNetUsers_PainGuestID",
                        column: x => x.PainGuestID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainGuestAgreements_UserTermsAcceptances_UserTermsAcceptanceID",
                        column: x => x.UserTermsAcceptanceID,
                        principalTable: "UserTermsAcceptances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PainGuestRoomAllotments",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    B2BAccountRoomID = table.Column<string>(nullable: true),
                    PainGuestAgreementID = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    DateOfAllotment = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainGuestRoomAllotments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PainGuestRoomAllotments_B2BAccountRooms_B2BAccountRoomID",
                        column: x => x.B2BAccountRoomID,
                        principalTable: "B2BAccountRooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainGuestRoomAllotments_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainGuestRoomAllotments_PainGuestAgreements_PainGuestAgreementID",
                        column: x => x.PainGuestAgreementID,
                        principalTable: "PainGuestAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessLogs_UserID",
                table: "AccessLogs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_B2BAccountID",
                table: "AspNetUsers",
                column: "B2BAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_B2CObjectId",
                table: "AspNetUsers",
                column: "B2CObjectId",
                unique: true,
                filter: "[B2CObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedByUserID",
                table: "AspNetUsers",
                column: "CreatedByUserID",
                unique: true,
                filter: "[CreatedByUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LanguageID",
                table: "AspNetUsers",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccountInformations_B2BAccountID",
                table: "B2BAccountInformations",
                column: "B2BAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccountInformations_UserID",
                table: "B2BAccountInformations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccountRooms_B2BAccountID",
                table: "B2BAccountRooms",
                column: "B2BAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccountRooms_CreatedByUserID",
                table: "B2BAccountRooms",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccountRooms_PainGuestUserID",
                table: "B2BAccountRooms",
                column: "PainGuestUserID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccountRooms_UpdatedByUserID",
                table: "B2BAccountRooms",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccounts_BrokerUserID",
                table: "B2BAccounts",
                column: "BrokerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccounts_CreatedByUserID",
                table: "B2BAccounts",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccounts_HrManagerUserID",
                table: "B2BAccounts",
                column: "HrManagerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccounts_LanguageID",
                table: "B2BAccounts",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_B2BAccounts_UpdatedByUserID",
                table: "B2BAccounts",
                column: "UpdatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestAgreements_AdvanceRentTransactionID",
                table: "PainGuestAgreements",
                column: "AdvanceRentTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestAgreements_B2BAccountID",
                table: "PainGuestAgreements",
                column: "B2BAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestAgreements_CreatedByUserID",
                table: "PainGuestAgreements",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestAgreements_PainGuestID",
                table: "PainGuestAgreements",
                column: "PainGuestID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestAgreements_UserTermsAcceptanceID",
                table: "PainGuestAgreements",
                column: "UserTermsAcceptanceID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestRoomAllotments_B2BAccountRoomID",
                table: "PainGuestRoomAllotments",
                column: "B2BAccountRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestRoomAllotments_CreatedByUserID",
                table: "PainGuestRoomAllotments",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PainGuestRoomAllotments_PainGuestAgreementID",
                table: "PainGuestRoomAllotments",
                column: "PainGuestAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_RentTransactions_B2BAccountRoomID",
                table: "RentTransactions",
                column: "B2BAccountRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RentTransactions_CreatedByUserID",
                table: "RentTransactions",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RentTransactions_PainGuestID",
                table: "RentTransactions",
                column: "PainGuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_B2BAccountID",
                table: "Reviews",
                column: "B2BAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerID",
                table: "Reviews",
                column: "ReviewerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RoomID",
                table: "Reviews",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTermsAcceptances_TermsAndConditionsID",
                table: "UserTermsAcceptances",
                column: "TermsAndConditionsID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTermsAcceptances_UserID",
                table: "UserTermsAcceptances",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessLogs_AspNetUsers_UserID",
                table: "AccessLogs",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccountInformations_AspNetUsers_UserID",
                table: "B2BAccountInformations",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccountInformations_B2BAccounts_B2BAccountID",
                table: "B2BAccountInformations",
                column: "B2BAccountID",
                principalTable: "B2BAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccountRooms_AspNetUsers_CreatedByUserID",
                table: "B2BAccountRooms",
                column: "CreatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccountRooms_AspNetUsers_PainGuestUserID",
                table: "B2BAccountRooms",
                column: "PainGuestUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccountRooms_AspNetUsers_UpdatedByUserID",
                table: "B2BAccountRooms",
                column: "UpdatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccountRooms_B2BAccounts_B2BAccountID",
                table: "B2BAccountRooms",
                column: "B2BAccountID",
                principalTable: "B2BAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_BrokerUserID",
                table: "B2BAccounts",
                column: "BrokerUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_CreatedByUserID",
                table: "B2BAccounts",
                column: "CreatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_HrManagerUserID",
                table: "B2BAccounts",
                column: "HrManagerUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_UpdatedByUserID",
                table: "B2BAccounts",
                column: "UpdatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_BrokerUserID",
                table: "B2BAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_CreatedByUserID",
                table: "B2BAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_HrManagerUserID",
                table: "B2BAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BAccounts_AspNetUsers_UpdatedByUserID",
                table: "B2BAccounts");

            migrationBuilder.DropTable(
                name: "AccessLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "B2BAccountInformations");

            migrationBuilder.DropTable(
                name: "PainGuestRoomAllotments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PainGuestAgreements");

            migrationBuilder.DropTable(
                name: "RentTransactions");

            migrationBuilder.DropTable(
                name: "UserTermsAcceptances");

            migrationBuilder.DropTable(
                name: "B2BAccountRooms");

            migrationBuilder.DropTable(
                name: "TermsAndConditions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "B2BAccounts");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
