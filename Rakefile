require 'albacore'

CURRENT_PATH = File.expand_path(File.dirname(__FILE__))
VERSION = '1.5.0'
ARTIFACTS_PATH = File.join(CURRENT_PATH, 'artifacts')

def is_windows
  RbConfig::CONFIG['host_os'] =~ /mingw/
end

desc 'Get all the referenced packages'
exec :packages do |command|
  FileUtils.rm_rf('packages')
  command.command = 'tools/nuget'
  command.parameters "install #{Dir['**/packages.config'].first} -o packages"
end

desc 'Build the solution'
if is_windows
  msbuild :build => :assembly_info do |build|
    FileUtils.rm_rf(ARTIFACTS_PATH)
    build.solution = 'System.Monad.sln'
    build.properties = { :configuration => :Release, :OutputPath => ARTIFACTS_PATH }
    build.targets :Rebuild
    build.verbosity = 'quiet'
    build.parameters '/nologo'
  end
else
  xbuild :build => :assembly_info do |build|
    FileUtils.rm_rf(ARTIFACTS_PATH)
    build.solution = 'System.Monad.sln'
    build.properties = { :configuration => :Release, :OutputPath => ARTIFACTS_PATH }
    build.targets :Rebuild
    build.verbosity = 'quiet'
    build.parameters '/nologo'
  end
end

desc 'Run the specs'
nunit :specs => :build do |nunit|
  file = (is_windows && Dir['packages/**/nunit-console.exe'].first) || 'tools/nunit-console'
  nunit.command = file
  nunit.options '-noshadow'
  nunit.assemblies 'artifacts/System.Monad.Specs.dll'
  nunit.parameters '-nologo'
end

desc 'Version the assembly'
assemblyinfo :assembly_info do |asm|
  asm.version = VERSION
  asm.company_name = 'alex.falkowski'
  asm.product_name = 'System.Monad'
  asm.title = 'System.Monad'
  asm.description = 'Provides a monad namespace for imperative .NET applications.'
  asm.copyright = Time.now.strftime('%Y')
  asm.output_file = 'System.Monad/AssemblyInfo.cs'
end

desc 'Create the nuspec'
nuspec :nuget_spec do |nuspec|
  nuspec.id = 'System.Monad'
  nuspec.version = VERSION
  nuspec.authors = 'alex.falkowski'
  nuspec.description = 'System.Monad'
  nuspec.title = 'System.Monad'
  nuspec.language = 'en-AU'
  nuspec.projectUrl = 'https://github.com/alexfalkowski/System.Monad'
  nuspec.iconUrl = 'http://newartisans.com/files/2012/08/Monad.png'
  nuspec.working_directory = 'artifacts'
  nuspec.output_file = 'System.Monad.nuspec'
  nuspec.file 'System.Monad.dll', 'lib/net40'
end

desc 'Create the nuget package'
nugetpack :nuget_pack => :nuget_spec do |nuget|
  nuget.command = 'tools/nuget'
  nuget.nuspec = 'artifacts/System.Monad.nuspec'
  nuget.output = 'artifacts'
end

desc 'Push the nuget package'
nugetpush :nuget_push => :nuget_pack do |nuget|
  nuget.command = 'tools/nuget'
  nuget.apikey = '30ab3856-f684-4d0e-9e5e-b8282cdf6fa7'
  nuget.package = "artifacts/System.Monad.#{VERSION}.nupkg"
end