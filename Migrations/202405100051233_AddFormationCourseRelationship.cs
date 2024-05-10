namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFormationCourseRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        formationID = c.Int(nullable: false, identity: true),
                        formationName = c.String(),
                        time = c.DateTime(nullable: false),
                        isAvaible = c.Boolean(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.formationID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Formations", "CourseID", "dbo.Courses");
            DropIndex("dbo.Formations", new[] { "CourseID" });
            DropTable("dbo.Formations");
        }
    }
}
