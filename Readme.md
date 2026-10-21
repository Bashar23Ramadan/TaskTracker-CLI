# Task Tracker CLI 🚀

أداة سطر أوامر (CLI) بسيطة وخفيفة لإدارة مهامك اليومية محلياً، مبنية بلغة **C#** وتعتمد على تخزين البيانات في ملف **JSON**. تم تطوير هذا المشروع كجزء من تحديات التطوير الخلفي في موقع **[roadmap.sh/projects/task-tracker](https://roadmap.sh/projects/task-tracker)**.

---

## 📋 المميزات (Features)
- تخزين محلي آمن وسريع باستخدام ملف `tasks.json`.
- توليد تلقائي لمعرفات المهام (IDs) الفريدة.
- تتبع تواريخ الإنشاء والتحديث بدقة لكل مهمة.
- إمكانية تصفية المهام بناءً على حالتها (`todo`, `in-progress`, `done`).
- تصميم هيكلي نظيف يعتمد على مبادئ الـ Clean Architecture.

---

## 🛠️ الأوامر المدعومة (Commands & Usage)

يمكنك تشغيل الأداة عبر سطر الأوامر (CMD أو PowerShell) باستخدام الأوامر التالية:

| الأمر | الوصف | مثال |
| :--- | :--- | :--- |
| `add` | إضافة مهمة جديدة | `task-cli add "Buy groceries"` |
| `update` | تحديث وصف مهمة بناءً على الـ ID | `task-cli update 1 "Buy groceries and vegetables"` |
| `delete` | حذف مهمة بناءً على الـ ID | `task-cli delete 1` |
| `mark-in-progress` | تغيير حالة المهمة إلى "قيد التنفيذ" | `task-cli mark-in-progress 1` |
| `mark-done` | تغيير حالة المهمة إلى "مكتملة" | `task-cli mark-done 1` |
| `list` | عرض جميع المهام | `task-cli list` |
| `list todo` | عرض المهام التي لم تبدأ بعد | `task-cli list todo` |
| `list in-progress` | عرض المهام قيد التنفيذ | `task-cli list in-progress` |
| `list done` | عرض المهام المكتملة | `task-cli list done` |
| `-help` | عرض قائمة المساعدة الأوامر | `task-cli -help` |

---

## ⚙️ متطلبات التشغيل (Prerequisites)
- يتطلب تشغيل البرنامج توفر بيئة **.NET 9** .

---

## 📦 التثبيت والتشغيل (Getting Started)

1. قم بعمل Clone للمستودع:
   ```bash
   git clone https://github.com/Bashar23Ramadan/TaskTracker-CLI