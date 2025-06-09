IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
newline db 13, 10, '$'
introMsg db "Welcome to the Roman numeral converter!$"
selectMsg db "Please select mode:", 10, 13, "1 - Decimal number to Roman numeral", 10, 13, "2 - Roman numeral to Decimal number", 10, 13, "3 - Exit", '$'
wrongInputMsg db "Wrong input! Please enter another input:$"
wrongNumberMsg db "Error! Not a number$"
wrongNumeralMsg db "Error! Not a roman numeral$"
numberInputMsg db "Please enter a number: (Press enter with an empty input to exit)$"
romanNumeralInputMsg db "Please enter a roman numeral: (Press enter with an empty input to exit)$"
exitMsg db "Closing converter$"
input db 11, ?, 11 dup(?)
numBytesOfInput db ?
numericResult dw 0
numeralResult dw ?
all_values dw 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1
all_numerals db "M$ ", "CM$", "D$ ", "CD$", "C$ ", "XC$", "L$ ", "XL$", "X$ ", "IX$", "V$ ", "IV$", "I$ "
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


proc PrintNumber
	push bp
	mov bp, sp
	
	mov ax, [bp + 4]
	
	; Enters into the stack the ASCII code for a new line
	mov bx, 13
	push bx
	mov bx, 10
	push bx
	
NumberToAscii:
	; Checks until the number is lesser than 10
	cmp ax, 10
	jb LastDigit
	
	; Divides the number by 10
	mov bx, 10
	xor dx, dx
	div bx
	
	; Pushes the remainder into the stack
	add dx, 30h
	push dx
	
	jmp NumberToAscii

LastDigit:
	; Turns the number into the ASCII code for the number
	add ax, 30h
	push ax

PrintNumberLoop:
	; Prints one digit
	pop dx
	mov ah, 2
	int 21h
	
	; Exits when the newline has been printed
	cmp dx, 13
	jne PrintNumberLoop
	
	pop bp
	ret 2
endp PrintNumber


proc StringToNumber
	push bp
	mov bp, sp
	
	mov [numeralResult], 0
	mov si, 2 ; Starting position in the input array
	mov bx, [bp + 4]
	
	; Move the length of the input into cl
	xor cx, cx	
	mov cl, [bx + 1]
	inc cl
	
StringToNumberLoop:
	; Multiplies the number by 10 in order to represent single digits, dozens, hundereds and thousands
	mov ax, [numeralResult]
	mov dx, 10
	mul dx
	mov [numeralResult], ax
	
	; Turns from ASCII code to number
	xor ax, ax
	mov al, [bx + si]
	sub al, 30h
	
	; Valid input check
	cmp al, 9
	ja NotNum
	cmp al, 0
	jb NotNum
	
	; In ax is the digit after the calculation for the correct place
	add [numeralResult], ax
	
	cmp si, cx
	inc si
	jb StringToNumberLoop
	jmp IsNum

NotNum:
	; Invalid input
	mov [numeralResult], -1
IsNum:
	pop bp
	ret 2
endp StringToNumber


; Compare given number with base values in the order 1000, 900, 500, 400, 100,
; 90, 50, 40, 10, 9, 5, 4, 1. Base value which is just smaller or equal to the
; given number will be the initial base value (largest base value). Divide the
; number by its largest base value, the corresponding base symbol will be
; repeated quotient times, the remainder will then become the number for
; future division and repetitions. The process will be repeated until the
; number becomes zero.
proc ConvertNumToRoman
	mov si, 0
NumberGreaterThanZero:
	; Divide number by the values in the order 1000, 900, 500, 400, 100, 90,
	; 50, 40, 10, 9, 5, 4, 1
	mov ax, [numeralResult]
	mov cx, [all_values + si]
	xor dx, dx
	div cx
	
	mov [numeralResult], dx
	mov bx, ax ; Quotient in bx
	cmp bx, 0
	je NoQuotient
DupChars:
	; If there is a remainder then the corresponding symbol will be repeated
	; quotient times
	mov ax, si
	mov cx, 2
	xor dx, dx
	div cx
	mov cx, 3
	mul cx
	
	; Prints the roman numeral in the corresponding spot to all_values
	mov dx, offset all_numerals
	add dx, ax
	mov ah, 9
	int 21h
	
	dec bx
	jnz DupChars
NoQuotient:
	add si, 2
	cmp [numeralResult], 0
	ja NumberGreaterThanZero
	
	ret
endp ConvertNumToRoman


proc NumToRoman
	jmp NumToRomanInputLoop
	
ErrorNum:
	push offset wrongNumberMsg
	call PrintMsg

NumToRomanInputLoop:
	push offset numberInputMsg
	call PrintMsg
	call NumInput
	
	cmp [input + 1], 0 ; User input is an empty string
	je EndNumToRomanInputLoop
	
	call PrintNewLine
	
	push offset input
	call StringToNumber
	
	cmp [numeralResult], -1
	je ErrorNum
	
	call ConvertNumToRoman
	call PrintNewLine
	
	jmp NumToRomanInputLoop
	
EndNumToRomanInputLoop:
	ret
endp NumToRoman


proc RomanToNum
	jmp RomanToNumInputLoop
	
ErrorRomanNumeral:
	push offset wrongNumeralMsg
	call PrintMsg

RomanToNumInputLoop:
	push offset romanNumeralInputMsg
	call PrintMsg
	call NumInput
	
	cmp [input + 1], 0 ; User input is an empty string
	je EndRomanToNumInputLoop
	
	push offset input
	call ConvertRomanToNum
	
	cmp [numericResult], -1
	je ErrorRomanNumeral
	
	mov ax, [numericResult]
	push ax
	call PrintNumber
	
	jmp RomanToNumInputLoop
	
EndRomanToNumInputLoop:
	ret
endp RomanToNum


; Split the Roman Numeral string into Roman Symbols (character).
; Convert each symbol of Roman Numerals into the value it represents.
; Take symbol one by one from starting from index 0:
; 	If current value of symbol is greater than or equal to the value of next
;	symbol, then add this value to the running total.
; 	else subtract this value by adding the value of next symbol to the running
;	total.
proc ConvertRomanToNum
	push bp
	mov bp, sp
	
	call PrintNewLine
	
	mov si, 2 ; Starting position in the input array
	mov bx, [bp + 4]
	
	; Move the length of the input into cl
	xor cx, cx	
	mov cl, [bx + 1]
	inc cl
	
	mov [numericResult], 0
	
RomanToNumLoop:
	mov dl, [bx + si]
	push dx
	call RomanToNumValue ; Value of roman numeral in number is in ax
	
	cmp ax, -1
	je NotRomanNumeral
	
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
	; Subtract this value by adding the value of next char to the final
	; result
	add [numericResult], ax
	sub [numericResult], di
	inc si
	jmp NextChar

NoNextChar:
	; Add the value to the final result
	add [numericResult], di

NextChar:
	cmp si, cx
	inc si
	jbe RomanToNumLoop
	
	jmp IsRomanNumeral
	
NotRomanNumeral:
	mov [numericResult], -1

IsRomanNumeral:
	pop bp
	ret	2
endp ConvertRomanToNum


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


proc PrintNewLine
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	ret
endp PrintNewLine


proc PrintMsg
	push bp
	mov bp, sp
	
	; Prints the message
	mov dx, [bp + 4]
	mov ah, 9
	int 21h
	
	call PrintNewLine
	
	pop bp
	ret 2
endp PrintMsg


proc SelectMode
StartSelection:
	push offset selectMsg
	call PrintMsg
	
InputLoop:
	; Get input of one char
	mov ah, 1h
	int 21h
	
	call PrintNewLine
	
	sub al, 30h ; convert from ascii to number
	
	cmp al, 1
	jne  RomanToNumCheck
	
	call NumToRoman
	jmp StartSelection
	
RomanToNumCheck:
	cmp al, 2
	jne ExitCheck
	
	call RomanToNum
	jmp StartSelection

ExitCheck:
	cmp al, 3
	je EndSelection
	
	; Wrong input entered - not 1-3
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
	push offset introMsg
	call PrintMsg
	
	call SelectMode
	
	; Exit the converter
	call PrintNewLine
	
	mov dx, offset exitMsg
	mov ah, 9
	int 21h
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


