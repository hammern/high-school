IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
number dw 0
msg db "How many numbers do you want to input?$"
numbers dw 1 dup(?)
; --------------------------
CODESEG

proc A
InputNumber:
	mov ah, 1
	int 21h
	
	cmp al, 0Dh
	je EndInput
	
	sub al, 30h
	
	mov cl, al
	mov ax, [number]
	
	mov bx, 10
	mul bx
	add al, cl
	mov [number], ax

	jmp InputNumber

EndInput:
	ret
endp A


proc B
	mov ax, [number]
	
NumberToAscii:
	cmp ax, 10
	jb LastDigit
	
	mov bx, 10
	xor dx, dx
	div bx
	
	add dx, 30h
	push dx
	
	jmp NumberToAscii

LastDigit:
	add ax, 30h
	push ax

PrintNumber:
	pop dx
	mov ah, 2
	int 21h
	cmp sp, 0FEh
	jb PrintNumber
	ret
endp B


proc C
	mov dx, offset msg
	mov ah, 9
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	mov ah, 1
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	xor cx, cx
	sub al, 30h
	mov cl, al
	xor si, si
	
InputNumbers:
	mov [number], 0
	push cx
	call A
	pop cx
	
	mov bx, [number]
	mov [numbers + si], bx
	add si, 2
	
	loop InputNumbers
	
	ret
endp C


proc D
	xor di, di
PrintArray:
	mov ax, [numbers + di]
	
NumToAscii:
	cmp ax, 10
	jb FinalDigit
	
	mov bx, 10
	xor dx, dx
	div bx
	
	add dx, 30h
	push dx
	
	jmp NumToAscii

FinalDigit:
	add ax, 30h
	push ax

PrintNum:
	pop dx
	mov ah, 2
	int 21h
	cmp sp, 0FEh
	jb PrintNum
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	add di, 2
	sub si, 2
	
	cmp si, 0
	jg PrintArray
	
	ret
endp D

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	call A
	
	call B
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	call C
	
	call D
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


