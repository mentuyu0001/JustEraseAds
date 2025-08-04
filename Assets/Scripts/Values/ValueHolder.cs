using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    // ’l‚ğ•Û‘¶‚µ‚ÄAæ“¾‚·‚éƒvƒƒOƒ‰ƒ€

    // •\¦‚·‚éL‚Ì”
    const int ADV_NUM = 19;

    // L‚Ìí—Ş‚Ì‘”
    const int ADV_KIND = 19;

    // ¶¬‚µ‚½L‚Ì”
    int createAdv;

    private void Start()
    {
        createAdv = 0;
    }

    // ‘S•”‚ÌL‚Ì”‚ğæ“¾‚·‚éŠÖ”
    public int get_ADV_NUM()
    {
        return ADV_NUM;
    }

    // L‚Ìí—Ş‚Ì”‚ğæ“¾‚·‚éŠÖ”
    public int get_ADV_KIND()
    {
        return ADV_KIND;
    }

    // ˆê‰ñL‚ğ¶¬‚µ‚½Û‚É‹N“®‚·‚éŠÖ”
    public void add_createAdv()
    {
        createAdv++;
    }

    // ¶¬‚µ‚½L‚Ì”‚ğæ“¾‚·‚éŠÖ”
    public int get_createAdv()
    {
        return createAdv;
    }
}
