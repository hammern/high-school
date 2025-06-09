IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
; --------------------------
CODESEG
	
proc PrintGreaterNum
	Num1 equ [bp + 6]
	Num2 equ [bp + 4]

	push bp
	mov bp, sp
	
	mov ax, Num1
	cmp ax, Num2
	ja FirstBigger
	
	mov dl, Num2
	mov ah, 2
	int 21h
	jmp EndCheck
	
FirstBigger:
	mov dl, Num1
	mov ah, 2
	int 21h

EndCheck:
	pop bp	
	ret 4
endp PrintGreaterNum


proc Subract
	Num1 equ [bp + 6]
	Num2 equ [bp + 4]

	push bp
	mov bp, sp
	
	mov ax, Num1
	cmp ax, Num2
	jae FirstBiggerF
	
	mov dl, '-'
	mov ah, 2
	int 21h
	
	mov ax, Num1
	mov bx, Num2
	sub bx, ax
	add bx, 30h
	mov dl, bl
	mov ah, 2
	int 21h
	jmp EndCheckF
	
FirstBiggerF:
	sub ax, Num2
	add al, 30h
	mov dl, al
	mov ah, 2
	int 21h

EndCheckF:
	pop bp	
	ret 4
endp Subract


start:
	mov ax, @data
	mov ds, ax
; --------------------------
	; A
	mov dl, 'A'
	mov ah, 2
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; B
	mov dl, 'a'
	mov ah, 2
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; C
	mov dl, 'H'
	mov ah, 2
	int 21h
	mov dl, 'E'
	mov ah, 2
	int 21h
	mov dl, 'L'
	mov ah, 2
	int 21h
	mov dl, 'L'
	mov ah, 2
	int 21h
	mov dl, 'O'
	mov ah, 2
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; D
	mov dl, 'H'
	mov ah, 2
	int 21h
	mov dl, 'E'
	mov ah, 2
	int 21h
	mov dl, 'L'
	mov ah, 2
	int 21h
	mov dl, 'L'
	mov ah, 2
	int 21h
	mov dl, 'O'
	mov ah, 2
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	mov dl, 'W'
	mov ah, 2
	int 21h
	mov dl, 'O'
	mov ah, 2
	int 21h
	mov dl, 'R'
	mov ah, 2
	int 21h
	mov dl, 'L'
	mov ah, 2
	int 21h
	mov dl, 'D'
	mov ah, 2
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; E
	mov cx, 2
Input:
	; Get input of single char
	mov ah, 1
	int 21h
	xor ah, ah
	push ax
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	loop Input
		
	call PrintGreaterNum
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; F
	mov cx, 2
InputF:
	; Get input of single char
	mov ah, 1
	int 21h
	xor ah, ah
	push ax
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	loop InputF
		
	call Subract
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


