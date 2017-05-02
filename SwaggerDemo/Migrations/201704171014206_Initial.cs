namespace SwaggerDemo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 256)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PointOfInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 256),
                        CityId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PointOfInterests", "CityId", "dbo.Cities");
            DropIndex("dbo.PointOfInterests", new[] { "CityId" });
            DropTable("dbo.PointOfInterests");
            DropTable("dbo.Cities");
        }
    }
}
