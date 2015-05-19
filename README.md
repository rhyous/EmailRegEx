# EmailRegEx
A project for doing a RFC compliant registration check of an email address.

The pattern to use is this one:

```
public static string ComplexEmailPattern4 = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" // local-part
      + "@"
      + @"((([\w]+([-\w]*[\w]+)*\.)+[a-zA-Z]+)|" // domain
      + @"((([01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]).){3}[01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))\z"; // or IP Address
```

And now because of the new changes to TLDs, a separate Tld validator is a good idea. So I added one.
