System.Monad
============

Provides a monad namespace for imperative .NET applications.

As stated on [wikipedia](http://en.wikipedia.org/wiki/Monad_(functional_programming))

	In functional programming, a monad is a structure that represents computations. A type with a monad structure defines what it means to chain operations of that type together. This allows the programmer to build pipelines that process data in steps, in which each action is decorated with additional processing rules provided by the monad. As such, monads have been described as "programmable semicolons"; a semicolon is the operator used to chain together individual statements in many imperative programming languages, thus the expression implies that extra code will be executed between the statements in the pipeline. Monads have been also explained with a physical metaphor as assembly lines, where a conveyor belt transports data between functional units that transform it one step at a time.
	
Maybe Monad
-----------

The Maybe monad represents computations which might "go wrong", in the sense of not returning a value. Why is this important?   

Tony Hoare apologized for inventing the null reference:

	I call it my billion-dollar mistake. It was the invention of the null reference in 1965. At that time, I was designing the first comprehensive type system for references in an object oriented language (ALGOL W). My goal was to ensure that all use of references should be absolutely safe, with checking performed automatically by the compiler. But I couldn't resist the temptation to put in a null reference, simply because it was so easy to implement. This has led to innumerable errors, vulnerabilities, and system crashes, which have probably caused a billion dollars of pain and damage in the last forty years.

 With that in mind we can write code as follows:

	public IOption<string> TransformValue(string value)
    {
        return value.SomeOrNone().Into(actual => actual + "Transform");
    }

 This will make sure that if we have a value we returned the transformed value and if not then it is a None. This also makes your intensions more explicit that the method can return None.