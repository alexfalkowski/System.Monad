require 'albacore'

CURRENT_PATH = File.expand_path File.dirname(__FILE__)

desc 'Get all the referenced packages'
exec :packages do |command|
  command.command = 'tools/nuget'
  command.parameters "install #{Dir['**/packages.config'].first} -o packages"
end

desc 'Build the solution'
xbuild :build do |build|
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