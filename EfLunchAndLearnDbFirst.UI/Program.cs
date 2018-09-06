using EfLunchAndLearnDbFirst.DataAccess;
using EfLunchAndLearnDbFirst.Repostiory;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfLunchAndLearnDbFirst.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var runner = new Runner();
            runner.Run();
        }
    }

    public class Runner
    {
        public void Run()
        {
            try
            {

                int importNameId = 0;
                int importTypeId = 0;
                int importStatusId = 0;
                var newImportName = new ImportName()
                {
                    ImportName1 = "NewName",
                };

                using (var context = new EfLunchAndLearnDbFirstContext())
                {
                    using (var genericIntRepo = new GenericRepository<EfLunchAndLearnDbFirstContext, ImportName>(context))
                    {
                        importNameId = genericIntRepo.Insert(newImportName);
                    }
                }

                var newImportType = new ImportType()
                {
                    ImportTypeDesc = "NewDesription",
                };

                using (var context = new EfLunchAndLearnDbFirstContext())
                {
                    using (var genericIntRepo = new GenericRepository<EfLunchAndLearnDbFirstContext, ImportType>(context))
                    {
                        importTypeId = genericIntRepo.Insert(newImportType);
                    }
                }

                var newImportStatus = new ImportStatus()
                {
                    ImportStatus1 = "NewStatus",
                };

                using (var context = new EfLunchAndLearnDbFirstContext())
                {
                    using (var genericIntRepo = new GenericRepository<EfLunchAndLearnDbFirstContext, ImportStatus>(context))
                    {
                        importStatusId = genericIntRepo.Insert(newImportStatus);
                    }
                }

                var newImportNameType = new ImportNameType()
                {
                    ImportNameId = importNameId,
                    ImportTypeId = importTypeId,
                    ImportStatusId = importStatusId,
                    IsHistorical = true
                };

                int importNameTypeToDelete = 0; 
                using (var context = new EfLunchAndLearnDbFirstContext())
                {
                    using (var genericIntRepo = new GenericRepository<EfLunchAndLearnDbFirstContext, ImportNameType>(context))
                    {
                        int importNameTypeId = genericIntRepo.Insert(newImportNameType);
                        importNameTypeToDelete = importNameTypeId;
                        var reloadedImportNameType = genericIntRepo.FindByKey(importNameTypeId);
                        var reloadedWithInclude = genericIntRepo.FindByKeyInclude(importNameTypeId, nt => nt.ImportName, nt => nt.ImportType, nt => nt.ImportStatus);

                        var findByReloaded = genericIntRepo.FindBy(nt => nt.ImportNameId == importNameId);

                        
                    }
                }

                using (var context = new EfLunchAndLearnDbFirstContext())
                {
                    using (var genericIntRepo = new GenericRepository<EfLunchAndLearnDbFirstContext, ImportNameType>(context))
                    {
                        var reloadedImportNameType = genericIntRepo.FindByKey(importNameTypeToDelete);
                        genericIntRepo.Delete(reloadedImportNameType);
                    }
                }
            }
            catch (Exception ex)
            {
                string mesage = ex.Message;
            }
        }
    }
}
