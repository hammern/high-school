IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
var1 db 50
var2 db 10
TimesToPrintX db 5
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
jmp E
; A
A:
	mov ax, 5
	cmp ax, 0
	jg decAx
	jmp exit
	
	decAx:
		dec ax
		cmp ax, 0
		jg decAx
	jmp exit

; B
B:
	mov ax, 5
	mov bx, 5
	cmp ax, bx
	jne copy
	jmp exit

	copy:
		mov ax, bx
	jmp exit

; C
C:
	mov ax, 2
	mov bl, [var1]
	cmp bl, [var2]
	ja greater
	mov ax, 0
	jmp exit

	greater:
		mov ax, 1
	jmp exit

; D
D:
	xor ax, ax
	xor bx, bx
	
	mov [var1], 11
	mov [var2], 10
	mov bl, [var1]
	cmp bl, [var2]
	je equal
	mov al, [var1]
	sub al, [var2]
	jmp exit

	equal:
		mov al, [var1]
		add al, [var2]
	jmp exit

; E
E:
	xor ax, ax
	cmp [TimesToPrintX], 0
	jle exit
	jmp PrintX
	
	PrintX:
		mov dl, 'x'
		mov ah, 2h
		int 21h
		inc bl
		cmp bl, [TimesToPrintX]
		jnae PrintX
	jmp exit
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


