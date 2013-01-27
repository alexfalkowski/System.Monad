require 'albacore'

CURRENT_PATH = File.expand_path File.dirname(__FILE__)

def create_executable(executable_name, executable_path)
  File.open(executable_name, 'w') do |file|
    combined_path = File.join(CURRENT_PATH, executable_path)
    file.write("exec mono --runtime=v4.0 #{combined_path} \"$@\"")
  end

  File.chmod(0700, executable_name)
end

desc 'Get all the referenced packages'
exec :packages do |command|
  create_executable('nuget', 'packages/NuGet.CommandLine.2.2.0/tools/NuGet.exe')
  command.command = './nuget'
  command.parameters "install #{Dir['./**/packages.config'].first} -o packages"
end

desc 'Build the solution'
xbuild :build do |build|
  artifacts_path = File.join(CURRENT_PATH, 'artifacts')

  build.solution = "System.Monad.sln"
  build.properties = { :configuration => :Release, :OutputPath => artifacts_path }
  build.targets :Rebuild
  build.verbosity = 'quiet'
end

desc 'Run the specs'
nunit :specs do |nunit|
  create_executable('nunit-console', 'packages/NUnit.2.5.10.11092/tools/nunit-console.exe')
  nunit.command = './nunit-console'
  nunit.options '-noshadow'
  nunit.assemblies 'artifacts/System.Monad.Specs.dll'
end