IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
FiveApostrophes db "*****$"
FiveApostrophesC db "*   *$"
; --------------------------
CODESEG

proc ApostropheA
	mov cx, 5

PrintA:
	mov dx, offset FiveApostrophes
	mov ah, 9
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	loop PrintA

	ret
endp ApostropheA


proc ApostropheB
	mov cx, 5
	mov si, 0
	
PrintB:	
	xor bx, bx
	
	PrintSpace:
		mov dl, ' '
		mov ah, 2
		int 21h
		
		cmp bx, si
		je PrintSpaceDone
		inc bx
		jmp PrintSpace
	
	PrintSpaceDone:
		mov dx, offset FiveApostrophes
		mov ah, 9
		int 21h
		
		; Newline
		mov dx, offset CRLF
		mov ah, 9
		int 21h
	
	inc si
	loop PrintB
	
	ret
endp ApostropheB


proc ApostropheC
	mov dx, offset FiveApostrophes
	mov ah, 9
	int 21h
		
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	mov cx, 3
	
	PrintC:
		mov dx, offset FiveApostrophesC
		mov ah, 9
		int 21h
		
		; Newline
		mov dx, offset CRLF
		mov ah, 9
		int 21h
		
		loop PrintC
	
	mov dx, offset FiveApostrophes
	mov ah, 9
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	ret
endp ApostropheC


proc ApostropheD
	mov cx, 5
	mov si, 0

StartPrintD:
	xor bx, bx
	
	PrintSpaceD:	
		mov dl, ' '
		mov ah, 2
		int 21h
		
		cmp bx, si
		mov di, cx
		je PrintD
		inc bx
		jmp PrintSpaceD
	
	PrintD:
		mov dl, '*'
		mov ah, 2
		int 21h
		
		loop PrintD
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	inc si
	dec di
	cmp di, 0
	mov cx, di
	ja StartPrintD

	ret
endp ApostropheD

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	call ApostropheA
	
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	
	call ApostropheB
	
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	
	call ApostropheC
	
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	
	call ApostropheD
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


