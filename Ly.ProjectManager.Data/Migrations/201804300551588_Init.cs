namespace Ly.ProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        accountGuid = c.String(nullable: false, maxLength: 128),
                        accountIdentity = c.Int(nullable: false, identity: true),
                        accountNo = c.String(),
                        accountPwd = c.String(),
                        accountName = c.String(),
                        accountType = c.Int(nullable: false),
                        gender = c.Boolean(),
                        nation = c.String(),
                        birthday = c.String(),
                        accountCard = c.String(),
                        place = c.String(),
                        qq = c.String(),
                        wechat = c.String(),
                        phone = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.accountGuid);
            
            CreateTable(
                "dbo.AccountRole",
                c => new
                    {
                        accountRoleGuid = c.String(nullable: false, maxLength: 128),
                        accountRoleIdentity = c.Int(nullable: false, identity: true),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                        accountInfoGuid = c.String(),
                        roleInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.accountRoleGuid);
            
            CreateTable(
                "dbo.ClassInfo",
                c => new
                    {
                        classGuid = c.String(nullable: false, maxLength: 128),
                        classIdentity = c.Int(nullable: false, identity: true),
                        className = c.String(),
                        specialtiesName = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                        gradeInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.classGuid);
            
            CreateTable(
                "dbo.ClassManage",
                c => new
                    {
                        classManageGuid = c.String(nullable: false, maxLength: 128),
                        classManageIdentity = c.String(nullable: false),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        classInfoGuid = c.String(),
                        teacherInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.classManageGuid);
            
            CreateTable(
                "dbo.ClassStudent",
                c => new
                    {
                        stuGuid = c.String(nullable: false, maxLength: 128),
                        stuIdentity = c.Int(nullable: false, identity: true),
                        stuName = c.String(),
                        accountInfoGuid = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        classInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.stuGuid);
            
            CreateTable(
                "dbo.ClassTeacher",
                c => new
                    {
                        teacherGuid = c.String(nullable: false, maxLength: 128),
                        teacherIdentity = c.Int(nullable: false, identity: true),
                        teacherName = c.String(),
                        teacherType = c.Int(nullable: false),
                        accountInfoGuid = c.Int(nullable: false),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.teacherGuid);
            
            CreateTable(
                "dbo.DataDictionary",
                c => new
                    {
                        dataGuid = c.String(nullable: false, maxLength: 128),
                        dataIdentity = c.Int(nullable: false, identity: true),
                        parentGuid = c.String(),
                        dataName = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.dataGuid);
            
            CreateTable(
                "dbo.DefencePersonCharge",
                c => new
                    {
                        personChargeGuid = c.String(nullable: false, maxLength: 128),
                        personChargeIdentity = c.Int(nullable: false, identity: true),
                        personChargeName = c.String(),
                        accountInfoGuid = c.String(),
                        personChargeType = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.personChargeGuid);
            
            CreateTable(
                "dbo.Defense",
                c => new
                    {
                        defenseGuid = c.String(nullable: false, maxLength: 128),
                        defenseIdentity = c.String(nullable: false),
                        defenseClassroom = c.String(),
                        defenseStartTime = c.DateTime(),
                        defenseEndTime = c.DateTime(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.defenseGuid);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        gradeGuid = c.String(nullable: false, maxLength: 128),
                        gradeIdentity = c.Int(nullable: false, identity: true),
                        gradeName = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.gradeGuid);
            
            CreateTable(
                "dbo.SysModuleButton",
                c => new
                    {
                        btnGuid = c.String(nullable: false, maxLength: 128),
                        btnIdentity = c.Int(nullable: false, identity: true),
                        btnName = c.String(),
                        btnEncode = c.String(),
                        btnUri = c.String(),
                        btnEvent = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                        moduleInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.btnGuid);
            
            CreateTable(
                "dbo.SysModule",
                c => new
                    {
                        moduleGuid = c.String(nullable: false, maxLength: 128),
                        moduleIdentity = c.Int(nullable: false, identity: true),
                        parentGuid = c.String(),
                        moduleIcon = c.String(),
                        moduleUri = c.String(),
                        moduleTarget = c.String(),
                        moduleLv = c.String(),
                        moduleName = c.String(),
                        isMenu = c.Boolean(nullable: false),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.moduleGuid);
            
            CreateTable(
                "dbo.OperationLog",
                c => new
                    {
                        logGuid = c.String(nullable: false, maxLength: 128),
                        logIdentity = c.Int(nullable: false, identity: true),
                        logDetails = c.String(),
                        logType = c.String(),
                        operationTable = c.String(),
                        operationModuleGuid = c.String(),
                        operationType = c.String(),
                        operationDesc = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.logGuid);
            
            CreateTable(
                "dbo.ProjectDefenceResult",
                c => new
                    {
                        resultGuid = c.String(nullable: false, maxLength: 128),
                        resultIdentity = c.Int(nullable: false, identity: true),
                        resultEvaluate = c.String(),
                        resultScore = c.Decimal(precision: 18, scale: 2),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        projectInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.resultGuid);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        projectGuid = c.String(nullable: false, maxLength: 128),
                        projectIdentity = c.Int(nullable: false, identity: true),
                        projectStatus = c.String(),
                        projectName = c.String(),
                        projectDesc = c.String(),
                        projectTarget = c.String(),
                        startTime = c.DateTime(),
                        endTime = c.DateTime(),
                        projectStandingDocUri = c.String(),
                        projectPlanDocUri = c.String(),
                        projectDetailedDesignDocUri = c.String(),
                        projectPresentationAddressUri = c.String(),
                        DevelopmentBackground = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                        teamInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.projectGuid);
            
            CreateTable(
                "dbo.ProjectModule",
                c => new
                    {
                        projectModuleGuid = c.String(nullable: false, maxLength: 128),
                        projectModuleIdentity = c.Int(nullable: false, identity: true),
                        projectModuleName = c.String(),
                        priority = c.Int(nullable: false),
                        projectModuleStatus = c.String(),
                        deadline = c.DateTime(),
                        expectedStartTime = c.DateTime(),
                        actualStartTime = c.DateTime(),
                        chargePerson = c.String(),
                        completePerson = c.String(),
                        expectedWorkHours = c.Int(nullable: false),
                        actualWorkHours = c.Int(nullable: false),
                        projectModuleDesc = c.String(),
                        projectModuleType = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.projectModuleGuid);
            
            CreateTable(
                "dbo.ProjectPlan",
                c => new
                    {
                        planGuid = c.String(nullable: false, maxLength: 128),
                        planIdentity = c.Int(nullable: false, identity: true),
                        planName = c.String(),
                        startTime = c.DateTime(),
                        endTime = c.DateTime(),
                        planStatus = c.Boolean(nullable: false),
                        targetSpecialty = c.String(),
                        projectTechnicalPoint = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                        gradeInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.planGuid);
            
            CreateTable(
                "dbo.ProjectTeam",
                c => new
                    {
                        teamGuid = c.String(nullable: false, maxLength: 128),
                        teamIdentity = c.String(nullable: false),
                        teamName = c.String(),
                        allowCreateProjectCategory = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                        planInfoGuid = c.String(),
                        classInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.teamGuid);
            
            CreateTable(
                "dbo.RoleAuthentication",
                c => new
                    {
                        authGuid = c.String(nullable: false, maxLength: 128),
                        authModuleType = c.Int(nullable: false),
                        authModuleGuid = c.String(),
                        authRoleGuid = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.authGuid);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        roleGuid = c.String(nullable: false, maxLength: 128),
                        roleIdentity = c.Int(nullable: false, identity: true),
                        roleName = c.String(),
                        roleLv = c.Int(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.roleGuid);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        membersGuid = c.String(nullable: false, maxLength: 128),
                        membersIdentity = c.Int(nullable: false, identity: true),
                        membersName = c.String(),
                        accountInfoGuid = c.String(),
                        membersDuties = c.String(),
                        membersFunction = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        sortCode = c.Int(),
                        isEnabled = c.Boolean(nullable: true),
                        remarks = c.String(),
                        teamInfoGuid = c.String(),
                        roleInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.membersGuid);
            
            CreateTable(
                "dbo.TeamMembersResult",
                c => new
                    {
                        memberResultGuid = c.String(nullable: false, maxLength: 128),
                        memberResultIdentity = c.Int(nullable: false, identity: true),
                        memberResultEvaluate = c.String(),
                        memberResultScore = c.String(),
                        creatorUserId = c.String(),
                        creatorDateTime = c.DateTime(),
                        lastModifyUserId = c.String(),
                        lastModifyDateTime = c.DateTime(),
                        isDel = c.Boolean(nullable: false),
                        deleteUserId = c.String(),
                        deleteDateTime = c.DateTime(),
                        teamMembersInfoGuid = c.String(),
                    })
                .PrimaryKey(t => t.memberResultGuid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamMembersResult");
            DropTable("dbo.TeamMembers");
            DropTable("dbo.Role");
            DropTable("dbo.RoleAuthentication");
            DropTable("dbo.ProjectTeam");
            DropTable("dbo.ProjectPlan");
            DropTable("dbo.ProjectModule");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectDefenceResult");
            DropTable("dbo.OperationLog");
            DropTable("dbo.SysModule");
            DropTable("dbo.SysModuleButton");
            DropTable("dbo.Grade");
            DropTable("dbo.Defense");
            DropTable("dbo.DefencePersonCharge");
            DropTable("dbo.DataDictionary");
            DropTable("dbo.ClassTeacher");
            DropTable("dbo.ClassStudent");
            DropTable("dbo.ClassManage");
            DropTable("dbo.ClassInfo");
            DropTable("dbo.AccountRole");
            DropTable("dbo.Account");
        }
    }
}
