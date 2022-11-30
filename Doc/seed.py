import csv

with open('netoff.csv', 'rt') as f:
    cin = csv.reader(f)
    books = [row for row in cin]

#print(books)    

with open('seed.txt', 'wt') as seed:
    for book in books:
        if len(book) == 0:
            continue
        print('                new Book', file=seed)
        print('                {', file=seed)
        print('                    Title="{}";'.format(book[0]), file=seed)
        print('                    Price={};'.format(book[3][:-1]), file=seed)
        print('                    Publisher="{}";'.format(book[2]), file=seed)
        print('                },\n', file=seed)

