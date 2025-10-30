# 📊 WordStatistics

Простой анализатор текста, который считает частоты слов, находит самые популярные и умеет искать слова по префиксу.

## 🧠 Возможности

- Подсчёт количества вхождений каждого слова
- Поиск N самых частых слов .
- 
- Поиск слов по префиксу (например, все слова, начинающиеся с "pre")

## ⚙️ Пример

```csharp
string text = "Hello world! Hello ChatGPT.";

var freq = WordAnalyzer.CountWordFrequencies(text);
// freq = { ["hello"]=2, ["world"]=1, ["chatgpt"]=1 }

var top = WordAnalyzer.GetTopWords(text, 1);
// ["hello"]

var withPrefix = WordAnalyzer.FindWordsByPrefix(text, "ch");
// ["chatgpt"]
