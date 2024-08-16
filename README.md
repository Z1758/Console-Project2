# 랜덤 타워 디펜스



![i15607426341](https://github.com/user-attachments/assets/8d3c970f-eb84-4a39-9522-4c60bf74691e)


어떤 게임을 만들어볼까 고민 하던 중 

이런 랜덤 타워 디펜스를 구현 하는건 어떨까 하여 선택

<br/><br/><br/>





![새 캔버스](https://github.com/user-attachments/assets/e20ca75c-2866-484c-9e0e-cbbeefc8e987)

조잡하게 완성 된 구상도
<br/><br/><br/>





### 전체적인 게임의 흐름

![gm712537_luckydefense_main](https://github.com/user-attachments/assets/3c9c4146-4102-4bed-8a91-8b6d13976de6)

1. 한 좌표에서 생성 되는 적들이 같은 길을 순환 

2. 적의 수가 일정치 이상 넘어가면 패배 

3. 적을 쓰러트려 자원을 모아서 타워를 뽑거나 합쳐서 

4. 마지막 라운드 까지 버텨서 보스를 쓰러트리면 승리



<br/><br/><br/>

# 작업 순서
-----------------
### 1. 초기화 작업, 맵 출력
### 2. 적 생성, 이동, 제거
### 3. 타워 생성, 공격
### 4. 플레이어 조작
### 5. 타워 합성, 판매
### 6. 스테이지 설정, 패배, 승리
### 7. 마무리

-----------



<br/><br/><br/>

## 클래스
-------------------

![제목 없음-1](https://github.com/user-attachments/assets/76eed4b9-e5c0-487d-a1b2-202961f612c0)


이런 느낌으로 클래스를 구분 지어봤다



![33](https://github.com/user-attachments/assets/a7710904-ded0-46f6-9b8f-1f78015f7923)

동적 객체 타워와 적은 타이머로 움직임을 관리하고

맵은 메인에서 while문을 돌려서 계속 갱신





![34](https://github.com/user-attachments/assets/f7c44332-7cc8-44c6-b8d1-af07085eee36)

그리고 동적 객체들은 생성과 소멸이 자주 발생하기에 

오브젝트 풀링 기법을 활용 하여

플레이어 목숨 만큼의 적들을 미리 Queue에 담아 놓고 

타이머를 통해 적을 생성 해야 할 때마다 하나씩 꺼내 List에 담아 

활성화 된 적들을 관리한다




![35](https://github.com/user-attachments/assets/9200a58e-0e9c-41d9-a555-94bac797d5d8)

적의 체력이 바닥나 소멸 해야 할 때 List에서 제거 후 Queue에 반환 한다

<br/><br/><br/>
# 맵 출력
---------------

![Pasted image 20240814232016](https://github.com/user-attachments/assets/a621a84b-5efc-4863-a5cf-42ae23b0c1cd)


![Pasted image 20240814232033](https://github.com/user-attachments/assets/16e9e700-28bb-4eac-94f4-97870b2a85f3)

전에 만들었던 테트리스에서 만들었던 코드를 재활용

문자를 입력할 배열과 

색을 넣을 배열을 구분
<br/>
<br/>



![Pasted image 20240814232052](https://github.com/user-attachments/assets/1b3efbf3-1d35-4c62-ae32-2a08ddfd1d83)



그렇게 일단 맵부터 생성
<br/><br/>


![Pasted image 20240815003412](https://github.com/user-attachments/assets/b08c62f6-c75f-42a0-a29d-2269d39cf15c)

적이 지나는 길은 매번 갱신 해줘야 하기 때문에 

따로 길만 범위를 지정해 사용하려 했지만
<br/>

![3e4c529ecd03d5c8942a15077a464c24_res](https://github.com/user-attachments/assets/bf7ef1cf-0f8f-4de5-a01d-924d0bafa7e4)

더 간단하고 보기 좋게 만들 수 있지 않을까 고민 해본 결과
<br/><br/>


![Pasted image 20240815020902](https://github.com/user-attachments/assets/586d5a60-f6df-4422-97c3-df68efd36587)

Queue에 적의 길을 넣어두고 사용하니 훨씬 간단해졌다



![Pasted image 20240815021148](https://github.com/user-attachments/assets/22ccc573-c6c4-4c6e-885f-d5bfe2f5c5b5)


![Pasted image 20240815021135](https://github.com/user-attachments/assets/86bd4c80-94a6-42ae-b3b0-aacf0f96c54c)

그러나 사이즈를 늘려서 스톱워치를 통해 속도를 비교해보니 

배열이 훨씬 더 빠른게 아닌가

![1714c213ba87e94a 1](https://github.com/user-attachments/assets/2d2dc321-2a45-4978-a699-852d7633a575)

![Pasted image 20240815021311](https://github.com/user-attachments/assets/ce331471-1946-48cb-a6d6-f5b0c3aad955)

구조체로도 만들어 봤으나 확실히 배열을 이길순 없었다 

조금 불편하더라도 계속 반복문을 돌려서 호출 해야 하는 함수이니

속도가 빠른 쪽을 쓰는게 맞다 판단하여 결국 쓰던걸 쓰기로 했다

![Pasted image 20240815100521](https://github.com/user-attachments/assets/da87dfea-d22f-406c-af46-4ed579ff51da)


상수의 모음을 만들어둔 static 클래스 PixelType을 활용해 보기 쉽게 만들어주고

색상을 지정 해준 뒤 맵은 이렇게 끝내고서 다음 단계로 간다




<br/><br/><br/>
# 적 구현

----
### 생성

![12](https://github.com/user-attachments/assets/0bc7951f-3d93-4e72-b8da-5114f46667a8)

적의 정보는 StageManager의 딕셔너리에 저장 하고 

스테이지 레벨에 맞춰 정보를 꺼내며 생성 되는 적들에 초기화를 해준다

<br/>
### 이동

![ezgif-1-442d11ff1d](https://github.com/user-attachments/assets/a8dfb8b6-2733-4002-ae9c-e9e5f2271201)

적이 생성 될 때 타이머의 이벤트에 추가 되는데 

타이머가 0.1초 마다 반복 될 때마다 

적의 이동 함수가 호출 된다

그리고 호출 될 때마다 쿨다운을 체크 하는 변수를 증가 시켜 

이동 속도와 같은 값이 되면 그때 적이 이동한다



![Pasted image 20240815162314](https://github.com/user-attachments/assets/36d187a6-ae7d-4f0c-a412-1fc230b56c03)



적의 이동 함수는 적이 끝 부분에 도달 할 때마다 상태를 변경 해 

방향을 변경하도록 간단하게 구현



![5](https://github.com/user-attachments/assets/2fc0fa0a-e2fb-4cfb-b190-14f659bf70f6)

잘 움직인다


![6](https://github.com/user-attachments/assets/191cd480-33d5-44f6-809d-9be255dea847)

그리고 타이머를 적용해 매 초 마다 적을 생성하게 했다

<br/>
### 제거

![ezgif-7-f3f52b3b50](https://github.com/user-attachments/assets/70c48b26-4f1d-46cc-8df9-52b34c7c969c)

타워에게 공격 당해 적의 체력이 0 이하로 떨어지면 

GameManager의 이벤트를 호출하면서 

자기 자신을 매개 변수로 보내 List에서 제거 되고 Queue로 돌아간다


![7](https://github.com/user-attachments/assets/9bf48cfd-3b39-4044-a969-9494bab99ab1)

타워에게 공격 당했을 때 체력이 줄어야 하지만 

일시적으로 이동 할 때마다 체력이 줄어들게 만들어서 테스트 해본 결과

잘 적용 되는 듯 하다

적은 대강 구현이 끝났으니 다음은 타워를 구현 할 차례다





<br/><br/><br/>
# 타워 구현

----

![Pasted image 20240815210431](https://github.com/user-attachments/assets/03d4257d-31be-4302-bc5f-dd69edc07c6b)

적과 타워의 비활성화와 타이머의 이벤트로 받는 움직임은 

비슷한 로직이기에 인터페이스로 상속 했다
<br/>
## 생성

![11](https://github.com/user-attachments/assets/def47cff-0258-4949-8a75-499b97e92674)

타워의 생성은 랜덤으로 값을 받아오고 그 값에 맞는 타워의 정보를 

Queue에서 꺼내온 타워 객체에 초기화 해준다


<br/>
## 공격

타이머를 통해 행동 하는 것은 비슷하나 

타워는 공격 조건이 충족 되면

자신을 매개 변수로 GameManager의 타워의 충돌 확인 이벤트를 호출 하고

타워의 범위와 List에 담겨 있는 적들 중 좌표가 일치 하는 적을 찾아서 

해당 적의 TakeDamage 함수를 호출해 데미지를 입힌다


![Pasted image 20240815214655](https://github.com/user-attachments/assets/114c763e-ce46-464d-8195-878ac289a0af)

대략 이런 흐름




![10](https://github.com/user-attachments/assets/f0ec1803-b2e9-4cd7-bf64-77b79a685d24)

타워의 공격에 적이 제거 당하고 있다






<br/><br/><br/>
## 플레이어 조작 
----



동적 객체들의 구현이 거의 끝났으니 이제 플레이어의 조작을 구현하면 되겠다

Player는 GameManager의 인스턴스로 저장 했다
<br/>
### 이동
![13](https://github.com/user-attachments/assets/532cfdef-ec9c-442c-8b63-98ee438e7d2a)

이동의 구현은 화살표 키 입력을 받고 범위를 제한한 좌표 값만 변경 해주면 되기 때문에 간단했다

<br/>
### 타워 뽑기

![14](https://github.com/user-attachments/assets/2952fce2-fb8f-4b87-b1c6-5fce5df27a2f)

특정 키를 입력 했을 때 

StageManager에 저장된 골드 변수의 값이 감소하며

랜덤 값을 넘겨주고 플레이어 좌표에 타워를 생성 시킨다
<br/>
### 타워 합치기

![16](https://github.com/user-attachments/assets/ded97d41-5573-451d-ba2f-eab5315c7c40)

플레이어 좌표에 있는 타워의 종류와 같은 타워를 찾아 3개 이상일 경우 3개의 타워를 지우고 

상위 등급의 랜덤한 타워를 생성 시킨다
<br/>
### 타워 판매
![15](https://github.com/user-attachments/assets/7e4acacb-2c79-4cc4-8095-723baa588cff)


플레이어 좌표 위의 타워를 지운다 즉 List에서 제거 하고 Queue에 저장한다

그리고 StageManager의 골드 변수의 값이 증가 한다




<br/><br/><br/>
## 게임 클리어, 게임 오버
------


![19](https://github.com/user-attachments/assets/3cd05bc3-9d2b-47ff-93fa-99a042bce255)

적이 일정 수를 넘어서거나 보스를 제한 시간내 쓰러트리지 못하면 패배하며  
게임 오버 씬이 출력 된다 


![18](https://github.com/user-attachments/assets/fd16bc0b-d719-4e3d-82a1-0fa7ad8ace45)

마지막 스테이지에서 보스를 쓰러트리면 클리어가 출력 된다



<br/><br/><br/>
## 마무리 작업

----

![20](https://github.com/user-attachments/assets/9f0b60f5-810f-433b-a559-f2f89560d424)
 
적 뒤에 숫자를 붙여 적이 겹쳐 있을 때의 확인과 문자수가 차이나는걸 해결

![21](https://github.com/user-attachments/assets/44b84403-65bc-446c-ad4d-8d119e772e3b)

10 스테이지가 되면 보스가 등장


![22](https://github.com/user-attachments/assets/967ac892-cfb9-4eac-addb-2fea5a2cde74)

게임이 너무 정적인 듯 하여

적의 체력이 줄어들면 색상이 변경 되게 수정

또한 타워의 공격이 쿨다운 중일 때 흑백 처리를 하여 

더욱 동적으로 표현 할 수 있게 만들어 보았다


![24](https://github.com/user-attachments/assets/001a85a1-e1be-479c-8830-8935fa3ecdfd)

![페페개구리12 1](https://github.com/user-attachments/assets/49e172cf-c391-47ca-9a41-9e48604a4860)



![25](https://github.com/user-attachments/assets/b589e6b6-058d-4322-819b-3e232e3b0672)

라운드 시간과 스테이지, 체력 등 표시 해주고

이렇게 랜덤 타워 디펜스를 완성 시켰다


![E8uqGYZVIAcCR-i](https://github.com/user-attachments/assets/5f15f88b-4847-4e83-93e7-b5d63b06c5b1)





![26](https://github.com/user-attachments/assets/70d9bdd9-2fa9-4265-8ea8-bdc64bc1b2fb)

그러나 생각보다 너무 빨리 완성 되었기에 

어떤 기능을 더 추가 해볼까 고민하다가




![NB_qC6YRjH7hv6elNznBIBOBZ5AwE-PKYEWKcU03aFzGsc60bOt9KLxocyvB01OxAbOG8joW9mgkShFmTaTKsQ](https://github.com/user-attachments/assets/aed76e14-a0a6-4832-8ca1-4037dfeb3f52)

맵을 미로로 만들고 적에게 A* 알고리즘을 적용 해보기로 했다

<br/><br/><br/>
## 순서
----

### 1. 미로를 만든다
### 2. A* 알고리즘으로 미로의 최단 경로를 찾는다
### 3. 적들에게 최단 경로를 적용하여 이동 시킨다
### 4. 적이 목적지에 도달 했을 때 체력이 줄어든다



![yeGPQm36sDBWn9Q](https://github.com/user-attachments/assets/e99a4bee-21e2-47c0-8ecf-5912f5bb3f00)


대충 이런 느낌이 되지 않을까

일단 테스트용 프로젝트를 만들자

<br/>
# 미로
----


미로는 Binary Tree라는 간단한 알고리즘으로 구현 했다


![26](https://github.com/user-attachments/assets/9c3ae4c8-e9d6-45e9-aadb-bf7a2ab84ac4)

일단 외곽과 2의 배수의 칸을 막아주고


![27](https://github.com/user-attachments/assets/caba6d19-23ea-4f97-b442-f89e28da4d04)

외곽과 2의 배수의 칸은 제외하는 조건문을 걸고 

랜덤 함수를 돌려 밑이나 오른쪽을 뚫게 만들면 끝



![9b9daa0df048eabc82c659bc7967670d](https://github.com/user-attachments/assets/c4d83262-3d68-4a95-ae46-293aae005260)

걱정 했는데 금방 만들어서 다행이다


<br/>
# A*
____

![Illustration-of-A-algorithm-path-planning](https://github.com/user-attachments/assets/c9433332-21e6-44c8-bee4-32134a875886)

![i13291473274](https://github.com/user-attachments/assets/2088bfee-00ab-402b-9acd-1b6de5281330)




![28](https://github.com/user-attachments/assets/76369636-3455-4217-bc8b-4a540d65c817)

어디 괜찮은 예제가 없을까 찾던 중 교수님 깃허브에 올라와 있는 것을 발견



![156c5b1fddf2f5a4e](https://github.com/user-attachments/assets/eb6d2291-c027-4004-ba18-13161b4a7617)

# 카피


![m_1584583752_4411_1583802953ed991efcf5ae428497f50fc842678a50__mn773959__w504__h468__f38536__Ym202003 1](https://github.com/user-attachments/assets/4d28b1fc-3c05-427c-8a19-af3636873edb)

따라치면서 하나씩 분석 해보니

기본적으로 다익스트라 알고리즘과 비슷하지만 

휴리스틱 추정값이라는 가중치를 이용해 최단 경로를 구하는 알고리즘이였다


![제목 없음](https://github.com/user-attachments/assets/3b9cc6fa-30da-4b25-a12b-3fa176c278ca)
알고리즘의 작동 원리를 이해하기 쉽게 만들어주는 사이트가 있었다

https://www.101computing.net/a-star-search-algorithm/

이 사이트를 통해 대략적인 흐름을 파악하게 되었다


![29](https://github.com/user-attachments/assets/974bb5dd-f2e8-4560-ad1e-f17ae6b3c512)

그리고 만들어둔 미로에 접목 시켜보았다

이제 본 프로젝트에 클래스를 추가하고 적용 시켜보자
<br/>

# 적용
___


<br/>기존에 만든 맵을 0번 모드 

랜덤 맵을 1번 모드로 사용하기로 했다



1번 모드일 때 초기화 단계에서 

적들에게 A스타 알고리즘으로 구한 길을 입력 시키고 

그 길을 따라 이동 시키도록 구현 

![30](https://github.com/user-attachments/assets/99fc393d-5fd9-4176-8436-6f8eb1d71040)

잘 찾아간다
  


![20220311083837_1EfHk5lPk0](https://github.com/user-attachments/assets/df05ed69-b2a1-406c-a232-1c947a227904)
하지만 만들고 나서 든 생각이지만 이러면 굳이 미로가 될 필요가 있을까?

  
![31](https://github.com/user-attachments/assets/14bcad91-e9eb-4b24-b879-8ee2863bf1f3)

결국 미로가 의미 없다 생각하여 적이 지나는 길 외엔 전부 유저의 공간으로 메꿔버렸다

  


![32](https://github.com/user-attachments/assets/700649f4-81d6-4592-95d7-76bf3a934880)

적이 지나는 길에 타워가 생성 되거나 
플레이어와 적의 좌표가 오버랩 되면 적이 이상하게 나오는 등 
여러 버그가 있었으나 수정하고 
적이 목적지에 도달 했을 때 플레이어의 체력이 줄어드는 것까지 구현하였다

  
  

# 끝
_______
![제목 없음-1](https://github.com/user-attachments/assets/fc83150d-dfc4-4322-909b-fb185dd180f2)

전체적인 씬의 흐름은 대략 이렇다
<br/><br/><br/>
  
  
![E-U9cMJ2qVCiG5Vse65G_E4-Cb5Xg](https://github.com/user-attachments/assets/58ca587a-71e4-4b14-b2b7-e602ad4c593b)

  

아쉬운점은 미로 맵이 설계 단계에 없었기 때문에 

급하게 추가하다가 코드가 많이 지저분해졌고

적의 체력 표시를 구현하다 타이머로 인해

색상이 잠깐 다르게 보이는 버그가 생겼다

다음에는 기능의 수정, 추가가 쉽도록 설계를 더 탄탄히 해야겠다
