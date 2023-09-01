using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Context;

public partial class FrostlineGamesDbContext : DbContext
{
    public FrostlineGamesDbContext()
    {
    }

    public FrostlineGamesDbContext(DbContextOptions<FrostlineGamesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abilitiess> Abilitiesses { get; set; }

    public virtual DbSet<AbilityAndAbilityCategory> AbilityAndAbilityCategories { get; set; }

    public virtual DbSet<AbilityAndAbilityCombo> AbilityAndAbilityCombos { get; set; }

    public virtual DbSet<AbilityAndAbilityLevel> AbilityAndAbilityLevels { get; set; }

    public virtual DbSet<AbilityCategory> AbilityCategories { get; set; }

    public virtual DbSet<AbilityCombo> AbilityCombos { get; set; }

    public virtual DbSet<AbilityDamageType> AbilityDamageTypes { get; set; }

    public virtual DbSet<AbilityDetail> AbilityDetails { get; set; }

    public virtual DbSet<AbilityEffectStat> AbilityEffectStats { get; set; }

    public virtual DbSet<AbilityImageFile> AbilityImageFiles { get; set; }

    public virtual DbSet<AbilityLevel> AbilityLevels { get; set; }

    public virtual DbSet<AbilityTargetType> AbilityTargetTypes { get; set; }

    public virtual DbSet<AbilityType> AbilityTypes { get; set; }

    public virtual DbSet<Banned> Banneds { get; set; }

    public virtual DbSet<BannedAndUsersDetail> BannedAndUsersDetails { get; set; }

    public virtual DbSet<Bard> Bards { get; set; }

    public virtual DbSet<BardAndEloRank> BardAndEloRanks { get; set; }

    public virtual DbSet<BardAndHero> BardAndHeros { get; set; }

    public virtual DbSet<BardAndLevel> BardAndLevels { get; set; }

    public virtual DbSet<BardAndMatchesRate> BardAndMatchesRates { get; set; }

    public virtual DbSet<BardAndSkin> BardAndSkins { get; set; }

    public virtual DbSet<BardDetail> BardDetails { get; set; }

    public virtual DbSet<BardEloRankPoint> BardEloRankPoints { get; set; }

    public virtual DbSet<BardExperiencePoint> BardExperiencePoints { get; set; }

    public virtual DbSet<BardIcon> BardIcons { get; set; }

    public virtual DbSet<BardImageFİle> BardImageFİles { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<BasketAndProduct> BasketAndProducts { get; set; }

    public virtual DbSet<BasketItem> BasketItems { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Coin> Coins { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<ContributionPoint> ContributionPoints { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<EffectType> EffectTypes { get; set; }

    public virtual DbSet<EloRank> EloRanks { get; set; }

    public virtual DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeApplication> EmployeeApplications { get; set; }

    public virtual DbSet<EndOfMatchInventory> EndOfMatchInventories { get; set; }

    public virtual DbSet<EndOfMatchInventoryAndItem> EndOfMatchInventoryAndItems { get; set; }

    //public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<GamCredit> GamCredits { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    public virtual DbSet<GetInTouch> GetInTouches { get; set; }

    public virtual DbSet<Hero> Heros { get; set; }

    public virtual DbSet<HeroAndSkin> HeroAndSkins { get; set; }

    public virtual DbSet<HeroDetail> HeroDetails { get; set; }

    public virtual DbSet<HeroStat> HeroStats { get; set; }

    public virtual DbSet<HeroStory> HeroStories { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemSet> ItemSets { get; set; }

    public virtual DbSet<ItemSetStat> ItemSetStats { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<MatchesRate> MatchesRates { get; set; }

    public virtual DbSet<OpenPosition> OpenPositions { get; set; }

    public virtual DbSet<OperationClaim> OperationClaims { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }

    public virtual DbSet<OurGame> OurGames { get; set; }

    public virtual DbSet<PossibleRequest> PossibleRequests { get; set; }

    public virtual DbSet<PossibleRequestAndTag> PossibleRequestAndTags { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImageFile> ProductImageFiles { get; set; }

    public virtual DbSet<Quality> Qualities { get; set; }

    public virtual DbSet<QualityEffect> QualityEffects { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Skin> Skins { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }

    public virtual DbSet<SupportRequest> SupportRequests { get; set; }

    public virtual DbSet<SupportRequestAndSupportRequestCategory> SupportRequestAndSupportRequestCategories { get; set; }

    public virtual DbSet<SupportRequestAndTag> SupportRequestAndTags { get; set; }

    public virtual DbSet<SupportRequestCategory> SupportRequestCategories { get; set; }

    public virtual DbSet<SupportRequestComment> SupportRequestComments { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamAndEmployee> TeamAndEmployees { get; set; }

    public virtual DbSet<Trigger> Triggers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserDetailImageFile> UserDetailImageFiles { get; set; }

    public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.56;Database=FrostlineGamesDb;User Id=frostline_adm;Password=dUT1@swl;TrustServerCertificate=True; Integrated Security =false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abilitiess>(entity =>
        {
            entity.ToTable("Abilitiess");

            entity.HasIndex(e => e.HeroId, "IX_Abilitiess_HeroId");

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IconUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Hero).WithMany(p => p.Abilitiesses).HasForeignKey(d => d.HeroId);
        });

        modelBuilder.Entity<AbilityAndAbilityCategory>(entity =>
        {
            entity.ToTable("AbilityAndAbilityCategory");

            entity.HasIndex(e => e.AbilityCategoryId, "IX_AbilityAndAbilityCategory_AbilityCategoryId");

            entity.HasIndex(e => e.AbilityId, "IX_AbilityAndAbilityCategory_AbilityId");

            entity.HasOne(d => d.AbilityCategory).WithMany(p => p.AbilityAndAbilityCategories).HasForeignKey(d => d.AbilityCategoryId);

            entity.HasOne(d => d.Ability).WithMany(p => p.AbilityAndAbilityCategories).HasForeignKey(d => d.AbilityId);
        });

        modelBuilder.Entity<AbilityAndAbilityCombo>(entity =>
        {
            entity.ToTable("AbilityAndAbilityCombo");

            entity.HasIndex(e => e.AbilityComboId, "IX_AbilityAndAbilityCombo_AbilityComboId");

            entity.HasIndex(e => e.AbilityId, "IX_AbilityAndAbilityCombo_AbilityId");

            entity.HasOne(d => d.AbilityCombo).WithMany(p => p.AbilityAndAbilityCombos).HasForeignKey(d => d.AbilityComboId);

            entity.HasOne(d => d.Ability).WithMany(p => p.AbilityAndAbilityCombos).HasForeignKey(d => d.AbilityId);
        });

        modelBuilder.Entity<AbilityAndAbilityLevel>(entity =>
        {
            entity.ToTable("AbilityAndAbilityLevel");

            entity.HasIndex(e => e.AbilityId, "IX_AbilityAndAbilityLevel_AbilityId");

            entity.HasIndex(e => e.AbilityLevelId, "IX_AbilityAndAbilityLevel_AbilityLevelId");

            entity.HasOne(d => d.Ability).WithMany(p => p.AbilityAndAbilityLevels).HasForeignKey(d => d.AbilityId);

            entity.HasOne(d => d.AbilityLevel).WithMany(p => p.AbilityAndAbilityLevels).HasForeignKey(d => d.AbilityLevelId);
        });

        modelBuilder.Entity<AbilityCategory>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<AbilityCombo>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.ComboEffect).HasMaxLength(100);
            entity.Property(e => e.ComboType).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<AbilityDamageType>(entity =>
        {
            entity.HasIndex(e => e.AbilityId, "IX_AbilityDamageTypes_AbilityId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Ability).WithOne(p => p.AbilityDamageType).HasForeignKey<AbilityDamageType>(d => d.AbilityId);
        });

        modelBuilder.Entity<AbilityDetail>(entity =>
        {
            entity.HasIndex(e => e.AbilityId, "IX_AbilityDetails_AbilityId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Ability).WithOne(p => p.AbilityDetail).HasForeignKey<AbilityDetail>(d => d.AbilityId);
        });

        modelBuilder.Entity<AbilityEffectStat>(entity =>
        {
            entity.HasIndex(e => e.AbilityId, "IX_AbilityEffectStats_AbilityId");

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Ability).WithMany(p => p.AbilityEffectStats).HasForeignKey(d => d.AbilityId);
        });

        modelBuilder.Entity<AbilityImageFile>(entity =>
        {
            entity.HasIndex(e => e.AbilityId, "IX_AbilityImageFiles_AbilityId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Ability).WithMany(p => p.AbilityImageFiles).HasForeignKey(d => d.AbilityId);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AbilityImageFile).HasForeignKey<AbilityImageFile>(d => d.Id);
        });

        modelBuilder.Entity<AbilityLevel>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<AbilityTargetType>(entity =>
        {
            entity.HasIndex(e => e.AbilityId, "IX_AbilityTargetTypes_AbilityId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Ability).WithOne(p => p.AbilityTargetType).HasForeignKey<AbilityTargetType>(d => d.AbilityId);
        });

        modelBuilder.Entity<AbilityType>(entity =>
        {
            entity.HasIndex(e => e.AbilityId, "IX_AbilityTypes_AbilityId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Ability).WithOne(p => p.AbilityType).HasForeignKey<AbilityType>(d => d.AbilityId);
        });

        modelBuilder.Entity<Banned>(entity =>
        {
            entity.ToTable("Banned");

            entity.Property(e => e.BanName).HasMaxLength(60);
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
        });

        modelBuilder.Entity<BannedAndUsersDetail>(entity =>
        {
            entity.HasIndex(e => e.BannedId, "IX_BannedAndUsersDetails_BannedId");

            entity.HasIndex(e => e.UserDetailId, "IX_BannedAndUsersDetails_UserDetailId");

            entity.HasOne(d => d.Banned).WithMany(p => p.BannedAndUsersDetails).HasForeignKey(d => d.BannedId);

            entity.HasOne(d => d.UserDetail).WithMany(p => p.BannedAndUsersDetails).HasForeignKey(d => d.UserDetailId);
        });

        modelBuilder.Entity<Bard>(entity =>
        {
            entity.HasIndex(e => e.BardIconId, "IX_Bards_BardIconId");

            entity.HasIndex(e => e.UserId, "IX_Bards_UserId");

            entity.Property(e => e.Code).HasMaxLength(60);

            entity.HasOne(d => d.BardIcon).WithMany(p => p.Bards).HasForeignKey(d => d.BardIconId);

            entity.HasOne(d => d.User).WithMany(p => p.Bards).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BardAndEloRank>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardAndEloRanks_BardId");

            entity.HasIndex(e => e.EloRankId, "IX_BardAndEloRanks_EloRankId");

            entity.HasOne(d => d.Bard).WithMany(p => p.BardAndEloRanks).HasForeignKey(d => d.BardId);

            entity.HasOne(d => d.EloRank).WithMany(p => p.BardAndEloRanks).HasForeignKey(d => d.EloRankId);
        });

        modelBuilder.Entity<BardAndHero>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardAndHeros_BardId");

            entity.HasIndex(e => e.HeroId, "IX_BardAndHeros_HeroId");

            entity.HasOne(d => d.Bard).WithMany(p => p.BardAndHeroes).HasForeignKey(d => d.BardId);

            entity.HasOne(d => d.Hero).WithMany(p => p.BardAndHeroes).HasForeignKey(d => d.HeroId);
        });

        modelBuilder.Entity<BardAndLevel>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardAndLevels_BardId");

            entity.HasIndex(e => e.LevelId, "IX_BardAndLevels_LevelId");

            entity.HasOne(d => d.Bard).WithMany(p => p.BardAndLevels).HasForeignKey(d => d.BardId);

            entity.HasOne(d => d.Level).WithMany(p => p.BardAndLevels).HasForeignKey(d => d.LevelId);
        });

        modelBuilder.Entity<BardAndMatchesRate>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardAndMatchesRates_BardId");

            entity.HasIndex(e => e.MatchesRateId, "IX_BardAndMatchesRates_MatchesRateId");

            entity.HasOne(d => d.Bard).WithMany(p => p.BardAndMatchesRates).HasForeignKey(d => d.BardId);

            entity.HasOne(d => d.MatchesRate).WithMany(p => p.BardAndMatchesRates).HasForeignKey(d => d.MatchesRateId);
        });

        modelBuilder.Entity<BardDetail>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardDetails_BardId").IsUnique();

            entity.HasOne(d => d.Bard).WithOne(p => p.BardDetail).HasForeignKey<BardDetail>(d => d.BardId);
        });

        modelBuilder.Entity<BardEloRankPoint>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardEloRankPoints_BardId");

            entity.HasOne(d => d.Bard).WithMany(p => p.BardEloRankPoints).HasForeignKey(d => d.BardId);
        });

        modelBuilder.Entity<BardExperiencePoint>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardExperiencePoints_BardId");

            entity.HasOne(d => d.Bard).WithMany(p => p.BardExperiencePoints).HasForeignKey(d => d.BardId);
        });

        modelBuilder.Entity<BardImageFİle>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_BardImageFİles_BardId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Bard).WithMany(p => p.BardImageFİles).HasForeignKey(d => d.BardId);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.BardImageFİle).HasForeignKey<BardImageFİle>(d => d.Id);
        });

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
        });

        modelBuilder.Entity<BasketAndProduct>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
        });

        modelBuilder.Entity<BasketItem>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<Coin>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.Property(e => e.AttributesName).HasMaxLength(60);
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<ContributionPoint>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_ContributionPoints_BardId");

            entity.HasOne(d => d.Bard).WithMany(p => p.ContributionPoints).HasForeignKey(d => d.BardId);
        });

        modelBuilder.Entity<Credit>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_Credits_BardId");

            entity.HasOne(d => d.Bard).WithMany(p => p.Credits).HasForeignKey(d => d.BardId);
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.NameOnCard).HasMaxLength(60);
        });

        modelBuilder.Entity<EffectType>(entity =>
        {
            entity.HasIndex(e => e.AbilityId, "IX_EffectTypes_AbilityId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Ability).WithOne(p => p.EffectType).HasForeignKey<EffectType>(d => d.AbilityId);
        });

        modelBuilder.Entity<EmailAuthenticator>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_EmailAuthenticators_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.EmailAuthenticators).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Employees_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Employees).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<EmployeeApplication>(entity =>
        {
            entity.Property(e => e.CvUrl).HasColumnName("CV_URL");
        });

        modelBuilder.Entity<EndOfMatchInventory>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_EndOfMatchInventories_BardId");

            entity.HasIndex(e => e.TeamId, "IX_EndOfMatchInventories_TeamId");

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);

            entity.HasOne(d => d.Bard).WithMany(p => p.EndOfMatchInventories).HasForeignKey(d => d.BardId);

            entity.HasOne(d => d.Team).WithMany(p => p.EndOfMatchInventories).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<EndOfMatchInventoryAndItem>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
        });

        modelBuilder.Entity<GamCredit>(entity =>
        {
            entity.HasIndex(e => e.BardId, "IX_GamCredits_BardId");

            entity.HasOne(d => d.Bard).WithMany(p => p.GamCredits).HasForeignKey(d => d.BardId);
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.ToTable("GameCategory");
        });

        modelBuilder.Entity<Hero>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.Region).HasMaxLength(60);
        });

        modelBuilder.Entity<HeroAndSkin>(entity =>
        {
            entity.HasIndex(e => e.HeroId, "IX_HeroAndSkins_HeroId");

            entity.HasIndex(e => e.SkinId, "IX_HeroAndSkins_SkinId");

            entity.Property(e => e.Code).HasMaxLength(60);

            entity.HasOne(d => d.Hero).WithMany(p => p.HeroAndSkins).HasForeignKey(d => d.HeroId);

            entity.HasOne(d => d.Skin).WithMany(p => p.HeroAndSkins).HasForeignKey(d => d.SkinId);
        });

        modelBuilder.Entity<HeroDetail>(entity =>
        {
            entity.HasIndex(e => e.HeroId, "IX_HeroDetails_HeroId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Story).HasMaxLength(60);
            entity.Property(e => e.Title).HasMaxLength(60);

            entity.HasOne(d => d.Hero).WithOne(p => p.HeroDetail).HasForeignKey<HeroDetail>(d => d.HeroId);
        });

        modelBuilder.Entity<HeroStat>(entity =>
        {
            entity.HasIndex(e => e.HeroId, "IX_HeroStats_HeroId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);

            entity.HasOne(d => d.Hero).WithOne(p => p.HeroStat).HasForeignKey<HeroStat>(d => d.HeroId);
        });

        modelBuilder.Entity<HeroStory>(entity =>
        {
            entity.HasIndex(e => e.HeroId, "IX_HeroStories_HeroId");

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.Story).HasMaxLength(400);

            entity.HasOne(d => d.Hero).WithMany(p => p.HeroStories).HasForeignKey(d => d.HeroId);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<ItemSet>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<ItemSetStat>(entity =>
        {
            entity.ToTable("ItemSetStat");

            entity.Property(e => e.Code).HasMaxLength(60);
        });

        modelBuilder.Entity<OperationClaim>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.OrderCode).HasMaxLength(60);
        });

        modelBuilder.Entity<OtpAuthenticator>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_OtpAuthenticators_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.OtpAuthenticators).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<OurGame>(entity =>
        {
            entity.HasIndex(e => e.GameCategoryId, "IX_OurGames_GameCategoryId");

            entity.HasOne(d => d.GameCategory).WithMany(p => p.OurGames).HasForeignKey(d => d.GameCategoryId);
        });

        modelBuilder.Entity<PossibleRequest>(entity =>
        {
            entity.HasIndex(e => e.SupportRequestCategoryId, "IX_PossibleRequests_SupportRequestCategoryId");

            entity.HasOne(d => d.SupportRequestCategory).WithMany(p => p.PossibleRequests).HasForeignKey(d => d.SupportRequestCategoryId);
        });

        modelBuilder.Entity<PossibleRequestAndTag>(entity =>
        {
            entity.HasIndex(e => e.PossibleRequestId, "IX_PossibleRequestAndTags_PossibleRequestId");

            entity.HasIndex(e => e.TagId, "IX_PossibleRequestAndTags_TagId");

            entity.Property(e => e.Code).HasMaxLength(60);

            entity.HasOne(d => d.PossibleRequest).WithMany(p => p.PossibleRequestAndTags).HasForeignKey(d => d.PossibleRequestId);

            entity.HasOne(d => d.Tag).WithMany(p => p.PossibleRequestAndTags).HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.Property(e => e.CategoryName).HasMaxLength(60);
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
        });

        modelBuilder.Entity<ProductImageFile>(entity =>
        {
            entity.HasIndex(e => e.ProductsId, "IX_ProductImageFiles_ProductsId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProductImageFile).HasForeignKey<ProductImageFile>(d => d.Id);

            entity.HasOne(d => d.Products).WithMany(p => p.ProductImageFiles).HasForeignKey(d => d.ProductsId);
        });

        modelBuilder.Entity<Quality>(entity =>
        {
            entity.HasIndex(e => e.ItemId, "IX_Qualities_ItemId").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);

            entity.HasOne(d => d.Item).WithOne(p => p.Quality).HasForeignKey<Quality>(d => d.ItemId);
        });

        modelBuilder.Entity<QualityEffect>(entity =>
        {
            entity.HasIndex(e => e.ConditionId, "IX_QualityEffects_ConditionId").IsUnique();

            entity.HasIndex(e => e.QualityId, "IX_QualityEffects_QualityId");

            entity.HasIndex(e => e.TriggerId, "IX_QualityEffects_TriggerId").IsUnique();

            entity.Property(e => e.AttributesName).HasMaxLength(60);
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.EffectDescription).HasMaxLength(60);
            entity.Property(e => e.EffectName).HasMaxLength(60);
            entity.Property(e => e.EffectTarget).HasMaxLength(60);

            entity.HasOne(d => d.Condition).WithOne(p => p.QualityEffect).HasForeignKey<QualityEffect>(d => d.ConditionId);

            entity.HasOne(d => d.Quality).WithMany(p => p.QualityEffects).HasForeignKey(d => d.QualityId);

            entity.HasOne(d => d.Trigger).WithOne(p => p.QualityEffect).HasForeignKey<QualityEffect>(d => d.TriggerId);
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_RefreshTokens_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Skin>(entity =>
        {
            entity.Property(e => e.Bytes).HasMaxLength(1);
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.FileExtension).HasMaxLength(60);
            entity.Property(e => e.ImageUrl).HasMaxLength(60);
            entity.Property(e => e.Title).HasMaxLength(60);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SubscriptionCategory>(entity =>
        {
            entity.Property(e => e.BuyingDate).HasColumnType("datetime");
            entity.Property(e => e.Code).HasMaxLength(1);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SupportRequest>(entity =>
        {
            entity.HasIndex(e => e.UserDetailId, "IX_SupportRequests_UserDetailId");

            entity.Property(e => e.UserEmail).HasMaxLength(60);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserIp)
                .HasMaxLength(60)
                .HasColumnName("UserIP");
            entity.Property(e => e.UserNickName).HasMaxLength(60);

            entity.HasOne(d => d.UserDetail).WithMany(p => p.SupportRequests).HasForeignKey(d => d.UserDetailId);
        });

        modelBuilder.Entity<SupportRequestAndSupportRequestCategory>(entity =>
        {
            entity.HasIndex(e => e.SupportRequestCategoryId, "IX_SupportRequestAndSupportRequestCategories_SupportRequestCategoryId");

            entity.HasIndex(e => e.SupportRequestId, "IX_SupportRequestAndSupportRequestCategories_SupportRequestId");

            entity.Property(e => e.Code).HasMaxLength(60);

            entity.HasOne(d => d.SupportRequestCategory).WithMany(p => p.SupportRequestAndSupportRequestCategories).HasForeignKey(d => d.SupportRequestCategoryId);

            entity.HasOne(d => d.SupportRequest).WithMany(p => p.SupportRequestAndSupportRequestCategories).HasForeignKey(d => d.SupportRequestId);
        });

        modelBuilder.Entity<SupportRequestAndTag>(entity =>
        {
            entity.HasIndex(e => e.RequestId, "IX_SupportRequestAndTags_RequestId");

            entity.HasIndex(e => e.TagId, "IX_SupportRequestAndTags_TagId");

            entity.HasOne(d => d.Request).WithMany(p => p.SupportRequestAndTags).HasForeignKey(d => d.RequestId);

            entity.HasOne(d => d.Tag).WithMany(p => p.SupportRequestAndTags).HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<SupportRequestComment>(entity =>
        {
            entity.HasIndex(e => e.SupportRequestId, "IX_SupportRequestComments_SupportRequestId");

            entity.HasIndex(e => e.UserId, "IX_SupportRequestComments_UserId");

            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Comment).HasMaxLength(60);
            entity.Property(e => e.UserName).HasMaxLength(60);
            entity.Property(e => e.UserRole).HasMaxLength(60);

            entity.HasOne(d => d.SupportRequest).WithMany(p => p.SupportRequestComments).HasForeignKey(d => d.SupportRequestId);

            entity.HasOne(d => d.User).WithMany(p => p.SupportRequestComments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<TeamAndEmployee>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_TeamAndEmployees_EmployeeId");

            entity.HasIndex(e => e.TeamId, "IX_TeamAndEmployees_TeamId");

            entity.HasOne(d => d.Employee).WithMany(p => p.TeamAndEmployees).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.Team).WithMany(p => p.TeamAndEmployees).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<Trigger>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(60);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasIndex(e => e.UserId, "UserId")
                .IsUnique()
                .HasFilter("([UserId] IS NOT NULL)");

            entity.HasOne(d => d.User).WithOne(p => p.UserDetail).HasForeignKey<UserDetail>(d => d.UserId);
        });

        modelBuilder.Entity<UserDetailImageFile>(entity =>
        {
            entity.HasIndex(e => e.UserDetailId, "IX_UserDetailImageFiles_UserDetailId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.UserDetailImageFile).HasForeignKey<UserDetailImageFile>(d => d.Id);

            entity.HasOne(d => d.UserDetail).WithMany(p => p.UserDetailImageFiles).HasForeignKey(d => d.UserDetailId);
        });

        modelBuilder.Entity<UserOperationClaim>(entity =>
        {
            entity.HasIndex(e => e.OperationClaimId, "IX_UserOperationClaims_OperationClaimId");

            entity.HasIndex(e => e.UserId, "IX_UserOperationClaims_UserId");

            entity.Property(e => e.Code).HasMaxLength(60);

            entity.HasOne(d => d.OperationClaim).WithMany(p => p.UserOperationClaims).HasForeignKey(d => d.OperationClaimId);

            entity.HasOne(d => d.User).WithMany(p => p.UserOperationClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
