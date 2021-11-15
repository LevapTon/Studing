a = ['a', 'b', 'c', 'd']
b = 'abcf'
c = 'focr\n'
for smb in c:
    print(smb)
    if smb != a:
        print('+')
    else:
        print('-')