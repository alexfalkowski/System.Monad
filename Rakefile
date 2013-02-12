require 'albacore'

CURRENT_PATH = File.expand_path File.dirname(__FILE__)
VERSION = '1.0.0'

desc 'Get all the referenced packages'
exec :packages do |command|
  command.command = 'tools/nuget'
  command.parameters "install #{Dir['**/packages.config'].first} -o packages"
end

desc 'Build the solution'
xbuild :build => :assembly_info do |build|
  artifacts_path = File.join(CURRENT_PATH, 'artifacts')

  build.solution = 'System.Monad.sln'
  build.properties = { :configuration => :Release, :OutputPath => artifacts_path }
  build.targets :Rebuild
  build.verbosity = 'quiet'
end

desc 'Run the specs'
nunit :specs do |nunit|
  nunit.command = 'tools/nunit-console'
  nunit.options '-noshadow'
  nunit.assemblies 'artifacts/System.Monad.Specs.dll'
end

desc 'Run a sample assembly info generator'
assemblyinfo :assembly_info do |asm|
  asm.version = VERSION
  asm.company_name = 'alex.falkowski'
  asm.product_name = 'System.Monad'
  asm.title = 'System.Monad'
  asm.description = 'System.Monad'
  asm.copyright = Time.now.strftime('%Y')
  asm.output_file = 'System.Monad/AssemblyInfo.cs'
end