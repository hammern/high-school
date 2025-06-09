IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
msg db 'Nadav Hammer$'
key db 10000001b
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
; Encryption
mov al, [key]
xor [msg], al
xor [msg + 1], al
xor [msg + 2], al
xor [msg + 3], al
xor [msg + 4], al
xor [msg + 5], al
xor [msg + 6], al
xor [msg + 7], al
xor [msg + 8], al
xor [msg + 9], al
xor [msg + 10], al
xor [msg + 11], al

; Decryption
xor [msg], al
xor [msg + 1], al
xor [msg + 2], al
xor [msg + 3], al
xor [msg + 4], al
xor [msg + 5], al
xor [msg + 6], al
xor [msg + 7], al
xor [msg + 8], al
xor [msg + 9], al
xor [msg + 10], al
xor [msg + 11], al

; Printing
print:
	mov dx, offset msg
	mov ah, 9h
	int 21h
	mov ah, 2
	mov dl, 10
	int 21h
	mov dl, 13
	int 21h
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


