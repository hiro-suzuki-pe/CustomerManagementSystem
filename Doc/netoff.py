import re
import csv
with open("Netoff文庫100選.csv","rt") as f:
    lines = f.readlines()

count = 0
books = []
book = []
for l in lines:
    l =re.sub("^\s*\d+,\s*", "", l)[:-1]
    l =re.sub("¥u3000", "", l)
    l =re.sub("\s*/\s*", "/", l)
    l = l.strip()
    if re.match('価格：\d+円 → \d+円\s*$', l):
        l = re.sub('価格：\s*', '', l)
        l = re.sub(' → \d+円\s*$', '', l)
        book.append(l)
        book = book[len(book)-4:]
        books.append(book)
        book = []
        count += 1
    elif re.match('.*/.*$', l):
        book += l.split('/')
    else:
        book.append(l)

for book in books:
    print(book)

with open('netoff.csv', 'w') as fout:
    writer = csv.writer(fout)
    writer.writerows(books)
