# Language Pak Specification

Language Paks are a way to easily export and import internationalized strings. The main parts of a Pak are as follows:
```
STRING_ID:STRING_VALUE
\COMMENT
{
    METADATA:INFO
}
```
## String setting and identificiation


A string is defined by its string id, which is a unique identifier for the string. String ids should be in the format `[a-zA-Z0-9_]+`.
