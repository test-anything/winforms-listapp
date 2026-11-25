# ListApp — Windows Forms

تطبيق Windows Forms بسيط: تكتب نص في الـ TextBox وتضغط **إضافة** (Button) فيُضاف إلى الـ **ListBox**. فيه كمان حذف العنصر المحدد ومسح الكل وعدّاد.

## التشغيل محلياً (Windows)
```
dotnet run --project ListApp
```

## CI/CD
الـ workflow `.github/workflows/build.yml` يشتغل على `windows-latest` مع كل push:
build → publish ملف EXE واحد (self-contained, win-x64) → يرفعه كـ Artifact.
عند دفع tag مثل `v1.0.0` ينشئ Release ويرفق فيه الملف.
