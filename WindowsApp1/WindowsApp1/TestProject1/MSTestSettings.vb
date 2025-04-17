Imports Microsoft.VisualStudio.TestTools.UnitTesting

' Disable parallel execution and ensure tests run sequentially at the method level.
<Assembly: Parallelize(Workers:=1, Scope:=ExecutionScope.MethodLevel)>
