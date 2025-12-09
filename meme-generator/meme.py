from PIL import Image, ImageDraw, ImageFont
import textwrap
import os

TEMPLATE_PATH = "images/template.jpg"
OUTPUT_DIR = "output"
FONT_PATH = None  # Можно подключить шрифт, если есть

def create_meme(text, output_name="meme.png"):
    # Открываем изображение
    img = Image.open(TEMPLATE_PATH)
    draw = ImageDraw.Draw(img)

    # Шрифт (если нет шрифта — используем дефолтный)
    font = ImageFont.truetype(FONT_PATH, 40) if FONT_PATH else ImageFont.load_default()

    # Перенос строк
    wrapped = textwrap.fill(text, width=25)

    # Размер текста
    w, h = draw.multiline_textsize(wrapped, font)

    # Координаты (центр сверху)
    img_w, img_h = img.size
    x = (img_w - w) // 2
    y = 20

    # Черная окантовка для читаемости
    outline_range = 2
    for dx in range(-outline_range, outline_range + 1):
        for dy in range(-outline_range, outline_range + 1):
            draw.multiline_text((x + dx, y + dy), wrapped, font=font, fill="black")

    # Основной белый текст
    draw.multiline_text((x, y), wrapped, font=font, fill="white")

    # Сохранение
    if not os.path.exists(OUTPUT_DIR):
        os.makedirs(OUTPUT_DIR)

    output_path = os.path.join(OUTPUT_DIR, output_name)
    img.save(output_path)
    print(f"Мем сохранён: {output_path}")

if __name__ == "__main__":
    user_text = input("Введи текст для мема: ")
    create_meme(user_text)
