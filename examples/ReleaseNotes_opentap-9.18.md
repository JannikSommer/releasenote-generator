Release Notes - opentap 9.18 
 ============= 

New Features 
 ------- 

- API for expanding/collapsing test steps heirachies [#332](https://github.com/opentap/opentap/issues/332)
- CLI SecureString support [#295](https://github.com/opentap/opentap/issues/295)
- Add generic CLI argument to name session log [#69](https://github.com/opentap/opentap/issues/69)


Bug Fixes 
 ------- 

- Race-Condition occurs if a TapThread is aborted too quickly after being started. [#632](https://github.com/opentap/opentap/issues/632)
- Annotation with null lists throws an exception [#629](https://github.com/opentap/opentap/issues/629)
- Multi-Selecting list-types is not working [#628](https://github.com/opentap/opentap/issues/628)
- Package install fails if ICustomTypeData inheritors throw in their constructor [#620](https://github.com/opentap/opentap/issues/620)
- instrument -> instrument reference bug [#613](https://github.com/opentap/opentap/issues/613)
- tap.exe fails to launch if System.Collections.Immutable 5.0 is in a subdirectory [#599](https://github.com/opentap/opentap/issues/599)
- XmlAttributeAttribute does not work for dynamic IMemberData [#570](https://github.com/opentap/opentap/issues/570)
- AssemblyVersion test fails intermittently [#559](https://github.com/opentap/opentap/issues/559)
- tap package install cannot be stopped when running in a test plan [#555](https://github.com/opentap/opentap/issues/555)
- HttpPackageRepositories 'DoDownloadPacakage' does not support authentication [#552](https://github.com/opentap/opentap/issues/552)
- Consistent installer failure (because of OS language?) [#548](https://github.com/opentap/opentap/issues/548)
- TypeData Attributes gets unintentionally inherited [#541](https://github.com/opentap/opentap/issues/541)
- TypeData made with FromType are sometimes unbrowsable [#537](https://github.com/opentap/opentap/issues/537)
- OpenTAP for Windows requires .NET Framework but does not install it [#534](https://github.com/opentap/opentap/issues/534)
- Cannot install a system wide package on Ubuntu [#528](https://github.com/opentap/opentap/issues/528)
- Saving component settings fails when its display attribute has Groups [#525](https://github.com/opentap/opentap/issues/525)
- Legacy Sweep Loop Range Can Iterate paramters of deleted steps [#481](https://github.com/opentap/opentap/issues/481)
- .net 472: Windows Principal functionality is not supported on this platform [#403](https://github.com/opentap/opentap/issues/403)
- Unable to create instance of OpenTap.NullTypeData [#329](https://github.com/opentap/opentap/issues/329)
- Downloading OpenTAP from documentation page doesn’t work   [#284](https://github.com/opentap/opentap/issues/284)
- The `PluginManager` loads assemblies that cannot be loaded [#230](https://github.com/opentap/opentap/issues/230)


Usability Improvements 
 ------- 

- Wrong error message when canceling elevated installs [#603](https://github.com/opentap/opentap/issues/603)
- Package install: Confusing error message when a package dependency is not in specified repositories [#563](https://github.com/opentap/opentap/issues/563)
- tap package install of file-like objects [#551](https://github.com/opentap/opentap/issues/551)
- Error in log when calling Installation.GetPackages from typedata providers [#538](https://github.com/opentap/opentap/issues/538)
- Retrying repo downloads 60 times in a loop is excessive [#529](https://github.com/opentap/opentap/issues/529)
- ITypeDataSource [#520](https://github.com/opentap/opentap/issues/520)
- OpenTap build improvement: log files are locked [#518](https://github.com/opentap/opentap/issues/518)
- Package Installation status is "Gathering dependencies" while installing system-wide packages [#513](https://github.com/opentap/opentap/issues/513)
- Warnings when installing a system wide package [#509](https://github.com/opentap/opentap/issues/509)
- tap run: no errors when specifying invalid external parameter values [#508](https://github.com/opentap/opentap/issues/508)
- If verdict step should not be allowed to bind to it's parent [#209](https://github.com/opentap/opentap/issues/209)
- Improve csproj OpenTapPackageReference error message [#112](https://github.com/opentap/opentap/issues/112)


Documentation 
 ------- 

- OpenTapApiReference copyright update to 2022 [#669](https://github.com/opentap/opentap/issues/669)
- Improve documentation of external parameters [#515](https://github.com/opentap/opentap/issues/515)
- Updated TUI location in developer guide [#495](https://github.com/opentap/opentap/issues/495)
- Update release notes to 9.17 on opentap.io [#483](https://github.com/opentap/opentap/issues/483)


Other 
 ------- 

- "PackageName exists in cache:..." printed out twice [#623](https://github.com/opentap/opentap/issues/623)
- Reduce the amount of logs when unable to connect to a package repository [#561](https://github.com/opentap/opentap/issues/561)
- HttpPackageRepository: Improve robustness of http requests [#560](https://github.com/opentap/opentap/issues/560)
- Create an engine setting to exchange an access token between plugins [#462](https://github.com/opentap/opentap/issues/462)
- Upgrade Newtonsoft to 12.0.3 [#445](https://github.com/opentap/opentap/issues/445)
- Performance Optimization Opportunities in ReflectionHelper [#359](https://github.com/opentap/opentap/issues/359)
- local/share on Linux has 2 folders named OpenTAP [#314](https://github.com/opentap/opentap/issues/314)
