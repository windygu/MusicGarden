# MusicGarden
MusicGarden
使用VS2015基于WMP组件开发，兼有搜索下载功能的音乐播放器,本项目没有使用数据库，仅仅在Windows10上测试。
<br><br>
## 版本
`master` 分支是最新的所有代码。

想打开软件运行？欢迎查看本仓库的 [Releases](https://github.com/jianyuyanyu/MusicGarden/releases)。
<br><br>
欢迎大家对软件进行修改添加新功能，[点击这里可以pull](https://github.com/jianyuyanyu/MusicGarden/pulls)。
<br><br>
## 代码结构说明
[MusicGarden](https://github.com/jianyuyanyu/MusicGarden)
```
│  MusicGarden.csproj
│  MusicGarden.csproj.user
│  packages.config
│  App.config
│  Dopamine.ico
│
├─Controllers
│      RootController.cs                   // api                                  根目录
│      CompaniesController.cs              // api/companies                        公司（单个/集合）
│      CompanyCollectionsController.cs     // api/companycollections               指定公司集合
│      EmployeesController.cs              // api/companies/{companyId}/employees  员工（单个/集合）
│      
├─Data
│      RoutineDbContext.cs
│      
├─DtoParameters                            // Uri query parameters
│      CompanyDtoParameters.cs             //  -GET api/companies   
│      EmployeeDtoParameters.cs            //  -GET api/companies/{companyId}/employees
│      
├─Entities
│      Company.cs
│      Employee.cs
│      Gender.cs
│      
├─Helpers
│      ArrayModelBinder.cs                 // 自定义 ModelBinder，将 ids 字符串转为 IEnumerable<Guid>
│      IEnumerableExtensions.cs            // IEnumerable<T> 拓展，对集合资源进行数据塑形
│      IQueryableExtensions.cs             // IQueryable<T> 拓展，对集合资源进行排序
│      ObjectExtensions.cs                 // Object 拓展，对单个资源进行数据塑形
│      PagedList.cs                        // 继承 List<T>，对集合资源进行翻页处理
│      ResourceUriType.cs                  // 枚举，指明 Uri 前往上一页、下一页或本页
│      
├─Migrations
│      ...
│      
├─Models
│      CompanyFriendlyDto.cs               // 公司简略信息 Dto
│      CompanyFullDto.cs                   // 公司完整信息 Dto
│      CompanyAddDto.cs                    // 添加公司时使用的 Dto
│      CompanyAddWithBankruptTimeDto.cs    // 添加已破产的公司时使用的 Dto
│      EmployeeDto.cs                      // 员工信息 Dto
│      EmployeeAddOrUpdateDto.cs           // 添加或更新员工信息时使用的 Dto 的父类
│      EmployeeAddDto.cs                   // 添加员工时使用的 Dto，继承 EmployeeAddOrUpdateDto
│      EmployeeUpdateDto.cs                // 更新员工信息时使用的 Dto，继承 EmployeeAddOrUpdateDto
│      LinkDto.cs                          // HATEOAS 的 links 使用的 Dto
│     
├─Profiles                                 // AutoMapper 映射关系
│      CompanyProfile.cs
│      EmployeeProfile.cs
│      
├─Properties
│      launchSettings.json
│      
├─Services
│      ICompanyRepository.cs
│      IPropertyCheckerService.cs
│      IPropertyMapping.cs
│      IPropertyMappingService.cs
│      CompanyRepository.cs
│      PropertyCheckerService.cs           // 判断 Uri query parameters 中的 fields 是否合法
│      PropertyMappingValue.cs             // 属性映射关系，用于集合资源的排序
│      PropertyMapping.cs                  // 属性映射关系字典，声明源类型与目标类型，用于集合资源的排序
│      PropertyMappingService.cs           // 属性映射关系服务，用于集合资源的排序
│      
└─ValidationAttributes                     // 自定义 Model 验证 Attribute
        EmployeeNoMustDifferentFromFirstNameAttribute.cs  
        
```
