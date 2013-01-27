require 'albacore'

desc 'Build the solution'
xbuild :build do |build|
  path = File.expand_path File.dirname(__FILE__)
  artifacts_path = File.join(path, 'artifacts')

  build.solution = "System.Monad.sln"
  build.properties = { :configuration => :Release, :OutputPath => artifacts_path }
  build.targets :Rebuild
  build.verbosity = 'quiet'
end

desc 'Run the specs'
nunit :specs do |nunit|
  nunit.command = 'nunit-console'
  nunit.options '-nologo -noshadow'
  nunit.assemblies 'artifacts/System.Monad.Specs.dll'
end