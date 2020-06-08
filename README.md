# Uni Multi Dictionary

1つのキーに対して複数の値を登録できる Dictionary  

## 使用例

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        var table = new MultiDictionary<string, string>
        {
            { "ほのお", "ヒトカゲ" },
            { "ほのお", "リザード" },
            { "ほのお", "リザードン" },
            { "でんき", "ピカチュウ" },
            { "でんき", "ライチュウ" }
        };

        foreach ( var pair in table )
        {
            foreach ( var value in pair.Value )
            {
                Debug.Log( $"{pair.Key}: {value}" );
            }
        }
    }
}
```
