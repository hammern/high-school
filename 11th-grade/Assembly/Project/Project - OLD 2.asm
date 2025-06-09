IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
newline db 13, 10, '$'
introMsg db "Welcome to the roman numeral converter!$"
selectMsg db "Please select mode:", 10, 13, "1 - Decimal number to Roman numeral", 10, 13, "2 - Roman numeral to Decimal number", 10, 13, "3 - Game", 10, 13, "4 - Exit", '$'
wrongInputMsg db "Wrong input! Please enter another input:$"
numberInputMsg db "Please enter a number:$"
romanNumeralInputMsg db "Please enter a roman numeral:$"
exitMsg db "Closing converter$"
finalResult dw 0
input db 11, ?, 11 dup(?)
numBytesOfInput db ?
number dw ?
all_values dw 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1
;all_values dw 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000
all_numerals db "M$ ", "CM$", "D$ ", "CD$", "C$ ", "XC$", "L$ ", "XL$", "X$ ", "IX$", "V$ ", "IV$", "I$ "
;all_numerals db "M$", "CM$", "D$", "CD$", "C$", "XC$", "L$", "XL$", "X$", "IX$", "V$", "IV$", "I$"
;all_numerals dw "M", "$", "CM", "$",  "D", "$",  "CD", "$",  "C", "$",  "XC", "$",  "L", "$",  "XL", "$",  "X", "$",  "IX", "$",  "V", "$",  "IV", "$", "I", "$"
;all_numerals dw 'I', 'IV', 'V', 'IX', 'X', 'XL', 'L', 'XC', 'C', 'CD', 'D', 'CM', 'M'
; --------------------------
CODESEG

proc NumInput
	mov dx, offset input
	mov ah, 0ah
	int 21h
	
	mov al, [input + 1] ; number of chars read
	mov bl, 2
	mul bl
	mov [numBytesOfInput], al ; actual number of bytes read
	
	ret
endp NumInput


proc ConvertRomanToNum
	push bp
	mov bp, sp
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	mov si, 2
	mov bx, [bp + 4]
	xor cx, cx
	mov cl, [bx + 1]
	inc cl
	
	mov [finalResult], 0
	
RomanToNumLoop:
	mov dl, [bx + si]
	push dx
	call RomanToNumValue
	mov bx, [bp + 4]
	
	mov di, ax ; first value in di
	
	; check if there is next char
	mov dx, si
	inc dx
	cmp dx, cx
	ja NoNextChar
	
	mov dl, [bx + si + 1] ; get next char
	push dx
	call RomanToNumValue
	mov bx, [bp + 4]
	; second value in ax
	cmp di, ax
	jnae DecreaseValue
	jmp NoNextChar
	
DecreaseValue:
	add [finalResult], ax
	sub [finalResult], di
	inc si
	jmp Temp

NoNextChar:
	add [finalResult], di

Temp:
	cmp si, cx
	inc si
	jbe RomanToNumLoop

	pop bp
	ret	2
endp ConvertRomanToNum


proc PrintNumber
	push bp
	mov bp, sp
	
	mov ax, [bp + 4]
	
	mov bx, 13
	push bx
	mov bx, 10
	push bx
	
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

PrintNumberLoop:
	pop dx
	mov ah, 2
	int 21h
	cmp dx, 13
	jne PrintNumberLoop
	
	pop bp
	ret 2
endp PrintNumber


proc StringToNumber
	push bp
	mov bp, sp
	
	mov [number], 0
	mov si, 2
	mov bx, [bp + 4]
	xor cx, cx
	mov cl, [bx + 1]
	inc cl
	
StringToNumberLoop:
	mov ax, [number]
	mov dx, 10
	mul dx
	mov [number], ax
	xor ax, ax
	mov al, [bx + si]
	sub al, 30h
	add [number], ax
	
	cmp si, cx
	inc si
	jb StringToNumberLoop
	
	pop bp
	ret 2
endp StringToNumber


proc ConvertNumToRoman
	mov si, 0
NumberGreaterThanZero:
	mov ax, [number]
	mov cx, [all_values + si]
	xor dx, dx
	div cx
	mov [number], dx
	mov bx, ax
	cmp bx, 0
	je NoQuotient
DupChars:
	mov ax, si
	mov cx, 2
	xor dx, dx
	div cx
	mov cx, 3
	mul cx
	
	mov dx, offset all_numerals
	add dx, ax
	mov ah, 9
	int 21h
	
	dec bx
	jnz DupChars
NoQuotient:
	add si, 2
	cmp [number], 0
	ja NumberGreaterThanZero
	
	ret
endp ConvertNumToRoman


proc NumToRoman
	push offset numberInputMsg
	call PrintMsg
	call NumInput
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	push offset input
	call StringToNumber
	
	call ConvertNumToRoman
	
	ret
endp NumToRoman


proc RomanToNum
	push offset romanNumeralInputMsg
	call PrintMsg
	call NumInput
	
	push offset input
	call ConvertRomanToNum
	mov ax, [finalResult]
	push ax
	call PrintNumber
	
	ret
endp RomanToNum


proc RomanToNumValue
	push bp
	mov bp, sp
	
	mov ax, [bp + 4]

	mov bx, 1
	cmp ax, 'I'
	je EndRomanToNumValue
	mov bx, 5
	cmp ax, 'V'
	je EndRomanToNumValue
	mov bx, 10
	cmp ax, 'X'
	je EndRomanToNumValue
	mov bx, 50
	cmp ax, 'L'
	je EndRomanToNumValue
	mov bx, 100
	cmp ax, 'C'
	je EndRomanToNumValue
	mov bx, 500
	cmp ax, 'D'
	je EndRomanToNumValue
	mov bx, 1000
	cmp ax, 'M'
	je EndRomanToNumValue
	mov bx, -1

EndRomanToNumValue:
	mov ax, bx
	
	pop bp
	ret 2
endp RomanToNumValue


proc Game
	
	
	ret
endp Game


proc PrintMsg
	push bp
	mov bp, sp
	
	; Prints the message
	mov dx, [bp + 4]
	mov ah, 9
	int 21h
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	pop bp
	ret 2
endp PrintMsg


proc SelectMode
	push offset selectMsg
	call PrintMsg
	
InputLoop:
	; Input
	mov ah, 1h
	int 21h
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	sub al, 30h ; convert from ascii to number
	
	; TODO: switch case - if num not equal, jump to next cmp. After function call jump to EndSelection
	cmp al, 1
	je NumToRomanL
	
	cmp al, 2
	je RomanToNumL
	
	cmp al, 3
	je GameL
	
	cmp al, 4
	je ExitConverter
	
	jmp WrongInput
	; TODO: loop the selected mode until the user presses escape

NumToRomanL:
	call NumToRoman
	jmp EndSelection

RomanToNumL:
	call RomanToNum
	jmp EndSelection

GameL:
	call Game
	jmp EndSelection


WrongInput:	
	; Wrong input entered - not 1-4
	push offset wrongInputMsg
	call PrintMsg
	
	jmp InputLoop ; Get another input
EndSelection:
	ret
endp SelectMode


start:
	mov ax, @data
	mov ds, ax
; --------------------------
	; Prints the message
	push offset introMsg
	call PrintMsg
	
	call SelectMode
	
	;push offset input
	;call PrintString
ExitConverter:
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	mov dx, offset exitMsg
	mov ah, 9
	int 21h
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


